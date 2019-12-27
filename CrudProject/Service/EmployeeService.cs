using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using CrudProject.Areas.Employee.Models;
using CrudProject.Data;
using CrudProject.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace CrudProject.Service
{
    public class EmployeeService:IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> SaveEmployee(Employee employee)
        {
            if (employee.id != 0)
            {
                _context.Employees.Update(employee);
                return 1 == await _context.SaveChangesAsync();
            }

            await _context.Employees.AddAsync(employee);
            return 1 == await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            var model = _context.Employees.Include(x=>x.Gender).AsNoTracking().ToList();
            return model;
        }

        public async Task<bool> DeleteEmployeeById(int id)
        {
            _context.Employees.Remove(_context.Employees.Find(id));
            return 1 == await _context.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = await _context.Employees.FindAsync(id);

            return employee;
        }
    }
}
