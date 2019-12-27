using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudProject.Areas.Employee.Models;
using CrudProject.Service.Interface;
using Microsoft.AspNetCore.Mvc;


namespace CrudProject.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IGenderService genderService;

        public EmployeeController(IEmployeeService employeeService, IGenderService genderService)
        {
            this.employeeService = employeeService;
            this.genderService = genderService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            EmployeeViewModel model = new EmployeeViewModel()
            {
                Employees = await employeeService.GetAllEmployee(),
                Genders = await genderService.GetAllGender()
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(Models.EmployeeViewModel employeeViewModel)
        {
            var msg = "nothing";

            if (!ModelState.IsValid)
            {
                return Json(msg);
            }

            Models.Employee employee = new Models.Employee()
            {
                name = employeeViewModel.name,
                genderId = employeeViewModel.genderId,
                email = employeeViewModel.email,
                phone = employeeViewModel.phone
            };

            await employeeService.SaveEmployee(employee);

            msg = "success";

            return Json(msg);
        }
    }
}
