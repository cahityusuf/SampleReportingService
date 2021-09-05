using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;
using Abstractions.Enums;

namespace Domain.Entities
{
    [Table("Reports", Schema = "ReportingService")]
    public class Reports : IEntity
    {
        public Reports()
        {
            ReportDetail = new HashSet<ReportDetail>();
        }

        public long Id { get; set; }
        public DateTime ReportDateTime { get; set; }
        public ReportStatusEnum ReportStatusId { get; set; }

        public ICollection<ReportDetail> ReportDetail { get; set; }

    }
}
