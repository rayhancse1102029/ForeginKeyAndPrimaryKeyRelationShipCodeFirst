using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProject.Areas.Employee.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string name { get; set; }

        public int genderId { get; set; }
        public Gender Gender { get; set; }

        [EmailAddress]
        public string email { get; set; }

        [Phone]
        public string phone { get; set; }

        
    }
}
