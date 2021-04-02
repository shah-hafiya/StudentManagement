using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseManagementService courseservice;
        public CourseController(ICourseManagementService courseservice)
        {
            this.courseservice = courseservice;
        }

        // GET: Course
        public ActionResult Index()
        {
            List<Course> courses = courseservice.GetAll();

            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            Course course = courseservice.GetById(id);
            return View(course);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
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
        public ActionResult Edit(int id)
        {
            Course course = courseservice.GetById(id);
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
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
        public ActionResult Delete(int id)
        {
            Course course = courseservice.GetById(id);
            return View(course);
        }

        // POST: Course/Delete/5
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
