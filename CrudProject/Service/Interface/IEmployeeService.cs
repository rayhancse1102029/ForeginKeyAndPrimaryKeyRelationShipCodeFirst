using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProject.Areas.Employee.Models;

namespace CrudProject.Service.Interface
{
    public interface IEmployeeService
    {
        Task<bool> SaveEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<bool> DeleteEmployeeById(int id);
        Task<Employee> GetEmployeeById(int id);
    }
}
