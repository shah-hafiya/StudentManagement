using System;
using System.Web.Mvc;
using System.Collections.Generic;
using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;

namespace StudentManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CourseController : Controller
    {
        private readonly ICourseManagementService courseservice;
        public CourseController(ICourseManagementService courseservice)
        {
            this.courseservice = courseservice;
        }

        // GET: Course
        [AllowAnonymous]
        public ActionResult Index(int page = 1)
        {
            var name = Request.QueryString["name"] ?? string.Empty;
            if (!string.IsNullOrEmpty(name))
                ViewBag.Name = name;
            
            var paginated = courseservice.GetAllCourses(page);
            return View(paginated);
        }

        // GET: Course/Details/5
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Course course = courseservice.GetById(id);
            return View(course);
        }

        // GET: Course/Create
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [AllowAnonymous]    
        public ActionResult Create(FormCollection collection, Course coursemodel)
        {
            try
            {
                // TODO: Add insert logic here
                courseservice.Add(coursemodel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        [AllowAnonymous]
        public ActionResult Edit(int id)
        {
            Course course = courseservice.GetById(id);
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Edit(int id, FormCollection collection, Course coursemodel)
        {
            try
            {
                courseservice.Update(coursemodel);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Course/Delete/5
        [AllowAnonymous]
        public ActionResult Delete(int id)
        {
            Course course = courseservice.GetById(id);
            return View(course);
        }

        // POST: Course/Delete/5
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {

                courseservice.Delete(id);

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
