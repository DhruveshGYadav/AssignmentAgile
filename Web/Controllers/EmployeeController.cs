using Common.Models;
using Common.Services.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeSerice _employeeService;
        public EmployeeController(IEmployeeSerice employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            try
            {                
                return View(_employeeService.GetEmployees());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee empobj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Files");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    string fileName = Guid.NewGuid().ToString() + empobj.File!.FileName;
                    string fileNameWithPath = Path.Combine(path, fileName);
                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        empobj.File.CopyTo(stream);
                    }
                    empobj.Photo = "/Files/" + fileName;
                    _employeeService.AddEmployee(empobj);                    
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return View(empobj);
        }        

        //ajax call for getting all employeelist for calendar controller.
        [HttpGet]
        public IActionResult GetEmployeeList()
        {
            try
            {
                return Ok(_employeeService.GetEmployees());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        
    }
}
