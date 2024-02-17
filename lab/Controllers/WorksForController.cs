using lab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
