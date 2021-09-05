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
        Task<IDataResult<ReportsDto>> ReportCreate();

        Task<IDataResult<ReportsDto>> ReportCapture(ReportsDto reports);
    }
}
