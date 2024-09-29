using Company.Data.Models;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Company.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService , IDepartmentService departmentService )
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            if (string.IsNullOrEmpty(searchInp))
            {
                var emp = _employeeService.GetAll();
                ViewBag.Message = "This is message from viewbag ";
                ViewData["TextMessage"] = "This is Message From VieDatag";
                TempData["TextMessage2"] = "This Is Message From TempData";
                return View(emp);
            }
            else
            {
                var emp = _employeeService.GetEmployeeByName(searchInp);
                return View();

            }
            

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("EmployeeError", "ValidationError");
                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("EmployeeError", ex.Message);
                return View(employee);

            }
        }
    }
}
