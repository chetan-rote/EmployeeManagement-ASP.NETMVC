using EmployeePayroll_ASP.NETMVC.Models;
using EmployeePayroll_ASP.NETMVC.Models.Common;
using EmployeePayroll_ASP.NETMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeePayroll_ASP.NETMVC.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeViewModel> list = employeeRepository.GetEmployees();
            return View(list);
        }

        // GET: Employee
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterEmployee(RegisterRequestModel employee)
        {
            bool result = false;
            if (ModelState.IsValid)
            {
                result = employeeRepository.RegisterEmployee(employee);
            }
            ModelState.Clear();

            if (result == true)
            {
                return RedirectToAction("Index");
            }
            return View(employee);
        }
    }
}