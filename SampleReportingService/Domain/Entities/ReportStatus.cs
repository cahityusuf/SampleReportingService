using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstractions.Data;

namespace Domain.Entities
{
    [Table("ReportStatus", Schema = "ReportingService")]
    public class ReportStatus:IEntity
    {
        public ReportStatus()
        {
            Reports = new HashSet<Reports>();
        }
        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Reports> Reports { get; set; }
    }
}
