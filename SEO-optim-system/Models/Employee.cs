using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEO_optim_system.Models
{
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Patronymic { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public AllDepartament Department { get; set; }
        public string PhoneNumber { get; set; }
        public int Experience { get; set; }
        public DateTime Birthday { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<Report> Reports { get; set; }

        public enum AllDepartament
        {
            Admin,
            Bookkeeping,
            Development,
            Marketing
        }
    }
}
