using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SEO_optim_system.Models
{
    public class Requirement
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Keywords { get; set; }
        public int GooglePoz { get; set; }
        public int YandexPoz { get; set; }
        public bool OptimImg { get; set; }
        public bool OptimText { get; set; }
        public bool OptimTag { get; set; }
    }
}
