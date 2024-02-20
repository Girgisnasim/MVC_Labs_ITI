//using AspNetCore;
using lab.Models;
using lab.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace lab.Controllers
{
    public class WorksForController : Controller
    {

        private ITIContext context;
        public WorksForController()
        {
            context = new ITIContext();
        }
        //get all
        public IActionResult Index()
        {
            List<Works_for> works = context.Works_For.Include(e=>e.EmpWorkFor).Include(p=>p.ProjWorkFor).ToList();
            // Create ViewBag to store colors
            List<string> colors = new List<string>();
            foreach (var work in works)
            {
                if(work.Hours > 50)
                {
                    colors.Add("green");

                }
                else
                {
                    colors.Add("red");
                }
            }

            ViewBag.Colors = colors;
            
            return View(works);
        }
        //get By Id
        public IActionResult Details(int id)
        {
            Employee employee = context.Employee.SingleOrDefault(e => e.SSN == id);

            if (employee == null)
            {
                return NotFound();
            }

            List<Works_for> worksForList = context.Works_For.Include(p => p.ProjWorkFor)
                                              .Where(w => w.ESSn == id)
                                              .ToList();

            ViewBag.EmployeeName = $"{employee.Fname} {employee.Lname}";
            List<string> colors = new List<string>();
            foreach (var work in worksForList)
            {
                if (work.Hours > 50)
                {
                    colors.Add("green");

                }
                else
                {
                    colors.Add("red");
                }
            }

            ViewBag.Colors = colors;

            return View(worksForList);
        }
        //======================================================================
        //edit operaion
        public IActionResult Edit(int id)
        {
            Employee emp = context.Employee.Where(p => p.SSN == id).SingleOrDefault();
            List<Project> project = context.Works_For.Include(w=>w.ProjWorkFor).Where(w=>w.ESSn == id).Select(p=>p.ProjWorkFor).ToList();
            
            ViewBag.project = project;
            ViewBag.employee= emp;
            return View();
        }

       
        public IActionResult editscript(int id , int ssn)
        {
            Works_for hours = context.Works_For.Where(w=>w.Pno == id && w.ESSn == ssn).FirstOrDefault();

            return PartialView("_editpartial",hours);

        }
    

    }
}
