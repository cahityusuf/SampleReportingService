using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;
using Abstractions.Dtos;
using Abstractions.Results;
using Abstractions.Services;
using Application.Constants;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ReportService : IReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReportService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IDataResult<ReportsDto>> GetByIdAsync(long id)
        {
            try
            {
                if (id == 0) return new ErrorDataResult<ReportsDto>(Messages.InvalidId);

                var _report = _unitOfWork.GetRepository<Reports>();

                var result = await _report.GetFirstOrDefaultAsync(predicate: p => p.Id == id,
                                                                    include: i => i.Include(c => c.ReportStatus));

                if (result != null)
                {
                    return new SuccessDataResult<ReportsDto>(_mapper.Map<ReportsDto>(result));
                }

                return new ErrorDataResult<ReportsDto>(Messages.Error);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<IDataResult<List<ReportsDto>>> GetListAsync()
        {
            var _report = _unitOfWork.GetRepository<Reports>();

            var result = await _report.GetAllAsync();

            if (result != null)
            {
                return new SuccessDataResult<List<ReportsDto>>(_mapper.Map<List<ReportsDto>>(result));
            }

            return new ErrorDataResult<List<ReportsDto>>(Messages.Error);
        }

        public async Task<IDataResult<ReportsDto>> InsertAsync(ReportsDto user)
        {
            if (user == null) return new ErrorDataResult<ReportsDto>(Messages.InvalidId);

            var _report = _unitOfWork.GetRepository<Reports>();

            var result = await _report.InsertAsync(_mapper.Map<Reports>(user));

            if (result != null)
            {
                var save = await _report.SaveChangesAsync();

                if (save > 0)
                {
                    return new SuccessDataResult<ReportsDto>(_mapper.Map<ReportsDto>(result));
                }

            }

            return new ErrorDataResult<ReportsDto>(Messages.Error);
        }

        public async Task<IDataResult<ReportsDto>> UpdateAsync(ReportsDto user)
        {
            if (user == null) return new ErrorDataResult<ReportsDto>(Messages.InvalidId);

            var _report = _unitOfWork.GetRepository<Reports>();

            _report.Update(_mapper.Map<Reports>(user));

            var result = await _report.SaveChangesAsync();

            if (result != 0)
            {
                return new SuccessDataResult<ReportsDto>(_mapper.Map<ReportsDto>(result));
            }

            return new ErrorDataResult<ReportsDto>(Messages.Error);
        }

        public async Task<IResult> DeleteAsync(long id)
        {
            if (id == 0) return new ErrorResult(Messages.InvalidId);

            var _report = _unitOfWork.GetRepository<Reports>();

            _report.Delete(id);

            var result = await _report.SaveChangesAsync();

            if (result != 0)
            {
                return new Result(true);
            }

            return new ErrorResult(Messages.Error);
        }
    }
}
