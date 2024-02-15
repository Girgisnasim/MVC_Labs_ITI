using lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab.Controllers
{
    public class DepartmentController : Controller
    {
        private ITIContext context;
        public DepartmentController()
        {
            context = new ITIContext();
        }
        //get all Department
        public IActionResult Index()
        {
            List<Department> departments = context.Department.ToList();
            return View(departments);
        }
        //get department by id
        public IActionResult Details(int id)
        {
            Department department = context.Department.Include(d => d.Leader).SingleOrDefault(d => d.Dnum == id);
            return View(department);
        }
        //CRUD Operations
        //Add or create
        //disply form
        public IActionResult GetAddForm()
        {
            List<Employee> mangers = context.Employee.Where(m=>m.Manage.MGRSSN == m.SSN).ToList();
            List<Employee> employees = context.Employee.ToList();
            List<Employee> poss=employees.Except(mangers).ToList();
            ViewData["poss"] = poss;

            return View();
        }
        //get form data
        public IActionResult GetFormData(Department department)
        {
            if (department.Dname != null)
            {
                context.Department.Add(department);
                context.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
                ViewBag.departments = context.Department.ToList();
                return View("Add");
            }
        }

        //Update
        // Edit 
        public IActionResult Edit(int id)
        {
            List<Employee> mangers = context.Department.Include(d => d.Leader).Where(d => d.Dnum != id).Select(d => d.Leader).ToList();

            List<Employee> restEmps = context.Employee.Where(e => !mangers.Contains(e)).ToList();
            Department department = context.Department.SingleOrDefault(d => d.Dnum == id);

            ViewData["poss"]= restEmps;
            return View(department);
        }
        public IActionResult EditDB(Department department)
        {
            // Server side validation
            if (department.Dname != null)
            {
                context.Department.Update(department);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.departments = context.Department.ToList();
                return View("Edit");
            }

        }
        public IActionResult Delete(int id)
        {
            Department department = context.Department.SingleOrDefault(d => d.Dnum == id);
            context.Department.Remove(department);
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
