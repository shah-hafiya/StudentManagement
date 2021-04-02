using System.Collections.Generic;
using System.Web.Mvc;
using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;

namespace StudentManagement.Controllers
{
    public enum Gender
    {
        Male,
        Female
    }
    public class StudentController : Controller
    {
        private readonly IStudentManagementService stdManagementService;
        public StudentController(IStudentManagementService stdManagementService)
        {
            this.stdManagementService = stdManagementService;
        }

        // GET: Student
        public ActionResult Index(int page = 1)
        {
            var students = stdManagementService.GetAllStudents(page, 10);
            return View(students);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            List<string> gender = new List<string>();
            gender.Add("Female");
            gender.Add("Male");

            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, Student studentmodel)
        {
            try
            {
                // TODO: Add insert logic here
                stdManagementService.Add(studentmodel);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            Student student = stdManagementService.GetById(id); //courseservice.GetById(id);
            return View(student);
            
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
