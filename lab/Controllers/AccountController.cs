using lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers
{
    public class AccountController : Controller
    {
        ITIContext context=new ITIContext();
        //display form
        public IActionResult login()
        {
            return View();
        }
        //get data
        public IActionResult loginDB(string name ,string password)
        {
            //check DB
            Employee employee = context.Employee.SingleOrDefault(e=>e.Fname == name && e.SSN==int.Parse(password));
            if (employee != null ) {
                //set session Data
                string s = employee.Fname;
                HttpContext.Session.SetString("name", employee.Fname);
                HttpContext.Session.SetInt32("id", employee.SSN);

                //return
                return RedirectToAction("Index", "Employee");
            }
            else
            {
                return View("login");
            }
           

            //return
        }
        //remove data
        //BOUNS
        public IActionResult logout()
        {
            // Clear session data
            HttpContext.Session.Clear();

            // Redirect to the login page or any other desired page
            return RedirectToAction("login");
        }
    }
}
