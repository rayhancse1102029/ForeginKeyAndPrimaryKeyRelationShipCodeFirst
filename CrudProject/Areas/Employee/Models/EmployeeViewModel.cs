using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudProject.Areas.Employee.Models
{
    public class EmployeeViewModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public int genderId { get; set; }

        public string email { get; set; }

        public string phone { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Gender> Genders { get; set; }
    }
}
