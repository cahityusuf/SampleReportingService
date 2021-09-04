using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;

namespace Domain.Entities
{
    [Table("Reports", Schema = "ReportingService")]
    public class Reports : IEntity
    {

        public long Id { get; set; }
        public DateTime ReportDateTime { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public int ReportStatusId { get; set; }

    }
}
