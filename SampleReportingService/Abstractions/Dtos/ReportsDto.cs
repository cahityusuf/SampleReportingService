using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Dtos
{
    public class ReportsDto : IDto
    {
        public long Id { get; set; }
        public DateTime ReportDateTime { get; set; }
        public ReportStatusDto ReportStatus { get; set; }
        public int ReportStatusId { get; set; }
    }
}
