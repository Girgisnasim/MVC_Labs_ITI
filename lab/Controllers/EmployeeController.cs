using lab.Models;
using lab.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        //Add
        [HttpGet]
        public IActionResult Add()
        {
            //ViewBag.departments= new SelectList(context.Department,nameof(Department.Dnum),nameof(Department.Dname));
            EmployeeVM employeeVM = new EmployeeVM
            {
                departments = new SelectList(context.Department, nameof(Department.Dnum), nameof(Department.Dname))
            };
            return View(employeeVM);

        }

    
        //AddDB
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(EmployeeVM emp) 
        {
            if (ModelState.IsValid)
            {
                Employee employee=new Employee
                {
                    SSN= emp.SSN,
                    Fname=emp.Fname,
                    Lname=emp.Lname,
                    Address=emp.Address,
                    Salary=emp.Salary,
                    Sex=emp.Sex,
                    Dno=emp.Dno,

                };
                context.Employee.Add(employee);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            //ViewBag.departments = new SelectList(context.Department, nameof(Department.Dnum), nameof(Department.Dname));
            emp.departments = new SelectList(context.Department, nameof(Department.Dnum), nameof(Department.Dname));
            return View(emp);
        }
    }
}
