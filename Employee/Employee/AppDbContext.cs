using Employee.Controllers;
using Employee.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Employee.Controllers.AdministratorController;

namespace Employee
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {

        }
        public DbSet<EmployeeProp> EmployeeProps { get; set; }
        public DbSet<EMPLeave> EMPLeaves { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeProp>().HasData(
                    new EmployeeProp
                    {
                        Id = 1,
                        Name = "shailesh",
                        Department = Dept.Hr,
                        Email = "shailesh@gmail.com"
                    }
                );
        }
    }
}
