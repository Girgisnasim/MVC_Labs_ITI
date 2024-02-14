using lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers
{
    public class EmployeeController : Controller
    {
        private ITIContext context;
        public EmployeeController()
        {
            context = new ITIContext();
        }
        //getAll

        public IActionResult Index()
        {
            List<Employee> employees = context.Employee.ToList();
            //transfer data
            return View(employees);
        }

        //by id
        public IActionResult Details(int id)
        {
            Employee employee = context.Employee.FirstOrDefault(e=>e.SSN==id);
            return View(employee);
        }
    }
}
