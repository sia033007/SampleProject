using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Person.Domain
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = string.Empty;
        [MaxLength(50)]
        [Required]
        public string CityType { get; set; } = string.Empty;
        [RegularExpression("^09(1[0-9]|3[1-9]|2[1-9])-?[0-9]{3}-?[0-9]{4}", ErrorMessage = "شماره همراه معتبر نیست")]
        [Required]
        public string PhoneNumber { get; set; } = string.Empty;
        public string CreatedTime { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;


    }
}
