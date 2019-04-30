using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SEO_optim_system.Models
{
    public class Company
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string LPR { get; set; }  // лицо, принимающее решения
        public string PhoneNumber { get; set; }
    }
}
