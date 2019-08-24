using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestPractice.Models
{
    public class Employee
    {
        [Key]
        public int EMPID { get; set; }
        [Column(TypeName ="datetime")]
        public DateTime HIREDATE { get; set; }
        [Column(TypeName = "int")]
        public int SALARY { get; set; }
        [Column(TypeName = "varchar(6)")]
        public string DEPT { get; set; }
        [Column(TypeName = "int")]
        public int JOBCODE { get; set; }
        [Column(TypeName = "varchar(10)")]
        public string SEX { get; set; }

    }
}
