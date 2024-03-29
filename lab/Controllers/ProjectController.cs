﻿using lab.Models;
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
        public IActionResult GetFormData(string name ,string Ploc, string city,int Dnum)
        {
            Project project = new Project()
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
        //Update
        //display form
        public IActionResult getEditForm(int id)
        {
            Project proj=context.Project.SingleOrDefault(p=>p.Pnumber==id);

            List<Department> departments = context.Department.ToList();
            ViewData["departments"] = departments;
            return View(proj);
        }
        //update form
        public IActionResult Update(int id, string name, string Ploc, string city, int Dnum)
        {
            Project project=context.Project.SingleOrDefault(p=> p.Pnumber== id);
            project.Pname= name;
            project.Plocation= Ploc;
            project.City= city;
            project.Dnum= Dnum;
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        //Delete
        public IActionResult Delete(int id)
        {
            Project project = context.Project.SingleOrDefault(p => p.Pnumber == id);
            context.Project.Remove(project);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
