using Person.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application
{
    public class DeletedContactDTO
    {
        public string Name { get; set; } = string.Empty;
        public string CityType { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
