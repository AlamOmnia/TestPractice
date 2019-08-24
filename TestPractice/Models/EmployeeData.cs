using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestPractice.Models
{
    public class EmployeeData
    {
        [Key]
        public int EMPID { get; set; }
        [Column (TypeName = "datetime")]
        public DateTime BIRTHDATE { get; set; }
        [Column(TypeName = "varchar(16)")]
        public string LASTNAME { get; set; }
        [Column(TypeName = "varchar(12)")]
        public string FIRSTNAME { get; set; }
        [Column(TypeName = "int")]
        public int PHONE { get; set; }
    }
}
