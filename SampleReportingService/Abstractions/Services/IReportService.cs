using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Dtos;
using Abstractions.Results;

namespace Abstractions.Services
{
    public interface IReportService:IBusinessService
    {
        Task<IDataResult<ReportsDto>> GetByIdAsync(long id);
        Task<IDataResult<List<ReportsDto>>> GetListAsync();
        Task<IDataResult<ReportsDto>> InsertAsync(ReportsDto user);

        Task<IDataResult<ReportsDto>> UpdateAsync(ReportsDto user);

        Task<IResult> DeleteAsync(long id);
    }
}
