using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestPractice.Models
{
    public class EmployeeContext: DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext>options):base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeData> EmployeeDatas { get; set; }
       
    }
}
