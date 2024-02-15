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
    }
}
