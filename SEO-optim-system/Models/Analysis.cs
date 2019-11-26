using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace SEO_optim_system.Models
{
    public class Analysis
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

        public double SQI { get; set; }
        public double Spam { get; set; }
        public double Trust { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
    }
}
