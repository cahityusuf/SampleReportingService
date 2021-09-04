using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Dtos
{
    public class ReportStatusDto:IDto
    { public int Id { get; set; }
        public string Status { get; set; }
    }
}
