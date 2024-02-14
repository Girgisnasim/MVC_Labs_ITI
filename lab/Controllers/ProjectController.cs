using lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab.Controllers
{
    public class ProjectController : Controller
    {
        private ITIContext context;
        public ProjectController()
        {
            context = new ITIContext();
        }

        //get all Projects
        public IActionResult Index()
        {
            List<Project> projects = context.Project.Include(p=>p.DeptProject).ToList();
            return View(projects);
        }   

        //get project by id
        public IActionResult Details(int id)
        {
            Project pro=context.Project.Include(p => p.DeptProject).SingleOrDefault(p=>p.Pnumber==id);
            return View(pro);
        }

        //CRUD Operations
        //Add or create
        //disply form
        public IActionResult GetAddForm()
        {
            List<Department> departments=context.Department.ToList();
            ViewData["departments"]=departments;
            return View(departments);
        }
        //get form data
        public IActionResult GetEditForm(string name ,string Ploc, string city,int Dnum)
        {
            Project project = new()
            {
                Pname = name,
                Plocation = Ploc,
                City = city,
                Dnum = Dnum
                
            };
            context.Project.Add(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
