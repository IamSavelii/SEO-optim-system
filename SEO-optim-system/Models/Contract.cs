using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEO_optim_system.Models
{
    public class Contract
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Url { get; set; }
        public int? CompanyId { get; set; }
        public Company Company { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string Keywords { get; set; }
        public int GooglePoz { get; set; }
        public int YandexPoz { get; set; }
        public bool OptimImg { get; set; }
        public bool OptimText { get; set; }
        public bool OptimTag { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
