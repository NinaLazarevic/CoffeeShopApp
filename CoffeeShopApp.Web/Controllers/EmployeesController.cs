using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeShopApp.Business.RepositoryLogic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopApp.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View(_employeeService.GetEmployees());
        }

        public IActionResult Delete(Guid id)
        {
            _employeeService.DeleteEmployee(id);

            TempData["UserInfo"] = "Employee with username \"" + _employeeService.GetEmployeeUsername(id) + "\" is deleted.";

            return RedirectToAction("Index");
        }
    }
}