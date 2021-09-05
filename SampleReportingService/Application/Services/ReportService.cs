using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        
                    _rabbitMqPublisher.Publish(new CreateReportMessage(){ReportId = result.Id});

                    return new SuccessDataResult<ReportsDto>(_mapper.Map<ReportsDto>(result));
                }

            }

            return new ErrorDataResult<ReportsDto>(Messages.Error);
        }
    }
}
