using System;
using System.Web.Mvc;
using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentManagementService stdService;

        public HomeController(IStudentManagementService stdService)
        {
            this.stdService = stdService;
        }

        public ActionResult Index()
        {
            //stdService.Add(new Student
            //{
            //    FirstName = "John",
            //    SurName = "Doe",
            //    Gender = "M",
            //    DOB = DateTime.Now,
            //    Address = new AddressDetails
            //    {
            //        Line1 = "1196  Morningview Lane",
            //        Line2 = "2201  Morningview Lane"
            //    }
            //});

            var students = stdService.Students;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}