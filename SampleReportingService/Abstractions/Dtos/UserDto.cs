using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstractions.Dtos
{
    public class UserDto : IDto
    {
        public UserDto()
        {
            ContactInfo = new HashSet<ContactInfoDto>();
        }
        public long Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Firma { get; set; }

        public virtual ICollection<ContactInfoDto> ContactInfo { get; set; }
    }
}
