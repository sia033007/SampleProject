using Person.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application
{
    public class ContactDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string CityType { get; set; } = string.Empty;
        [RegularExpression("^09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "شماره همراه معتبر نیست")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
