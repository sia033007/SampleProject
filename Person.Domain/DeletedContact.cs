using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Domain
{
    public class DeletedContact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        public string CityType { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
