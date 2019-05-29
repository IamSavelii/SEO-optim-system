using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SEO_optim_system.ViewModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Не указано отчество")]
        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Не указана фамилия")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Не указана должность")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Не указан отдел")]
        public AllDepartament Department { get; set; }
        public string PhoneNumber { get; set; }
        public int Experience { get; set; }
        public DateTime Birthday { get; set; }

        public enum AllDepartament
        {
            Admin,
            Bookkeeping,
            Development,
            Marketing
        }
    }
}
