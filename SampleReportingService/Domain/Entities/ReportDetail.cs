using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Entities
{
    [Table("ReportDetail", Schema = "ReportingService")]
    public class ReportDetail:IEntity
    {
        public long Id { get; set; }
        public string konum { get; set; }
        public long kisisayisi { get; set; }
        public long telefonsayisi { get; set; }
        public Reports Reports { get; set; }
        public long ReportsId { get; set; }
        public List<long> UserId { get; set; }
    }
}
