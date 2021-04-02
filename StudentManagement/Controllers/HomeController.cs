using System;
using System.Web.Mvc;
using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserManagementService userservice;

        public HomeController(IUserManagementService userservice)
        {
            this.userservice = userservice;
        }

        public ActionResult Index()
        {
            userservice.Add(new Student
            {
                FirstName = "John",
                SurName = "Doe",
                Gender = "M",
                DOB = DateTime.Now,
                Address = new AddressDetails
                {
                    Line1 = "1196  Morningview Lane",
                    Line2 = "2201  Morningview Lane"
                }
            });

            var students = userservice.Students;
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