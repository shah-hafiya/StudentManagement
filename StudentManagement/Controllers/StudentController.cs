using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentManagementService stdManagementService;
        private readonly ICourseManagementService courseservice;

        public StudentController(IStudentManagementService stdManagementService, ICourseManagementService courseservice)
        {
            this.stdManagementService = stdManagementService;
            this.courseservice = courseservice;
        }

        // GET: Student
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var students = stdManagementService.GetAllStudents(page, 10);
            return View(students);
        }

        // GET: Student/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            List<string> gender = new List<string>();
            gender.Add("Female");
            gender.Add("Male");

            var genderlist = new SelectList(gender);

            ViewBag.Gender = genderlist; //new SelectList(db.Accounts, "AccountId", "AccountName");

            List<Course> courses = courseservice.GetAll();
            ViewBag.courses = new MultiSelectList(courses, "Id", "CourseName" );


            return View();
        }

        // POST: Student/Create
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(StudentCreateVM studentmodel, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (Exception ex )
                { 
                    
                }


                var student = StudentVM.ToStudent(studentmodel);
                student.Password = studentmodel.Password;

                string courseIdstring = collection["Course"];
                string[] courseArr = courseIdstring.Split(',');

                if (courseArr.Length > 5)
                {
                    //throw new Exception("Cannot Select more than 5 course");
                    ModelState.AddModelError("", "Cannot Select more than 5 course");

                    List<string> gender = new List<string>();
                    gender.Add("Female");
                    gender.Add("Male");
                    var genderlist = new SelectList(gender);
                    ViewBag.Gender = genderlist;

                    List<Course> courses = courseservice.GetAll();
                    ViewBag.courses = new MultiSelectList(courses, "Id", "CourseName");


                    return View();
                }
                else
                {
                    foreach (string str in courseIdstring.Split(','))
                    {
                        Course c = courseservice.GetById(Convert.ToInt32(str));
                        student.Courses.Add(c);
                    }

                    stdManagementService.Add(student);

                    return RedirectToAction("Login", "Account");
                }

                
            }

            return View();
        }

        // GET: Student/Edit/5
        [AllowAnonymous]
        public ActionResult Edit(int id)
        {
            Student student = stdManagementService.GetById(id); //courseservice.GetById(id);
            return View(StudentVM.ToStudentVM(student));

        }

        // POST: Student/Edit/5
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Edit(int id, StudentVM studentmodel)
        {
            if (ModelState.IsValid)
            {
                var student = stdManagementService.GetById(id);

                if (student != null)
                {
                    student.FirstName = studentmodel.FirstName;
                    student.SurName = studentmodel.SurName;
                    student.Gender = studentmodel.Gender;
                    student.DOB = studentmodel.DOB;
                    student.Address.Line1 = studentmodel?.Line1;
                    student.Address.Line2 = studentmodel?.Line2;
                    student.Address.Line3 = studentmodel?.Line3;

                    stdManagementService.Update(student);

                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Student with {id} does not exists");
                }
            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Student student = stdManagementService.GetById(id); //courseservice.GetById(id);
            return View(StudentVM.ToStudentVM(student));

        }

        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var student = stdManagementService.GetById(id);

                if (student != null)
                {
                    stdManagementService.Delete(id);

                    return RedirectToAction("Index", "Student");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, $"Student with {id} does not exists");
                }
            }

            return View();
        }
    }
}
