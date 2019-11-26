using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEO_optim_system.Models
{
    public class seoContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Analysis> Analyses { get; set; }
        public seoContext(DbContextOptions<seoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
