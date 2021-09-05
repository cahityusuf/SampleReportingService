using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Abstractions.Data;
using Abstractions.Dtos;
using Abstractions.Enums;
using Abstractions.Results;
using Abstractions.Services;
using Application.Constants;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using RabbitMQ;
using RabbitMQ.Client.Events;

namespace Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RabbitMQPublisher _rabbitMqPublisher;
        public ReportService(IMapper mapper, IUnitOfWork unitOfWork, RabbitMQPublisher rabbitMqPublisher)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _rabbitMqPublisher = rabbitMqPublisher;

        }


        public async Task<IDataResult<ReportsDto>> ReportCreate()
        {
            var repository = _unitOfWork.GetRepository<Reports>();

            ReportsDto reports = new()
            {
                ReportDateTime = DateTime.Now,
                ReportStatusId = (int)ReportStatusEnum.Hazırlanıyor
            };

            var result = await repository.InsertAsync(_mapper.Map<Reports>(reports));

            if (result != null)
            {
                var save = await repository.SaveChangesAsync();

                if (save > 0)
                {

                    _rabbitMqPublisher.Publish(new CreateReportMessage() { ReportId = result.Id });

                    return new SuccessDataResult<ReportsDto>(_mapper.Map<ReportsDto>(result));
                }

            }

            return new ErrorDataResult<ReportsDto>(Messages.Error);
        }

        /// <summary>
        /// Worker Servisten raporun alındığına dair request geldi
        /// Report için oluşturulan kayıt "Hazırlanıyor" dan "Tamamlandı" ya çekilsin
        /// Ayrıca Rapor sonucunda oluşan Data rapor Id si ile saklansın.
        /// Dolayısıyla daha önce üretilen raporlara Reporting Serviceden ulaşılabilir.
        /// </summary>
        /// <param name="reports"></param>
        /// <returns></returns>
        public async Task<IDataResult<ReportsDto>> ReportCapture(ReportsDto reports)
        {
            var repository = _unitOfWork.GetRepository<Reports>();
            var repoReportsDetail = _unitOfWork.GetRepository<ReportDetail>();

            var result = await repository.FindAsync(reports.Id);

            if (result != null)
            {
                result.ReportStatusId = ReportStatusEnum.Tamamlandı;
                result.ReportDateTime = DateTime.Now;
                repository.Update(result);

                var reportDetail = _mapper.Map<List<ReportDetail>>(reports.ReportDetail.ToList());

                repoReportsDetail.Insert(reportDetail);

                var save = await repository.SaveChangesAsync();

                if (save > 0)
                {

                    return new SuccessDataResult<ReportsDto>(_mapper.Map<ReportsDto>(result));
                }
            }

            return new ErrorDataResult<ReportsDto>(Messages.Error);
        }

    }
}
