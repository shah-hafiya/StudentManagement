using StudentManagement.Api.Services;
using StudentManagement.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManagementService userService;

        public AccountController(IUserManagementService user)
        {
            this.userService = user;
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                if (Admin.FakeNames.Any(x => x.Equals(model.Name, StringComparison.OrdinalIgnoreCase))
                    && Admin.FakePasswords.Any(x => x.Equals(model.Password)))
                {
                    FormsAuthentication.SetAuthCookie(model.Name, true);
                }
                else
                {
                    var user = userService.GetUserInfo(model.Name, model.Password);

                    if (user == null)
                    {
                        ModelState.AddModelError(string.Empty, "Invalid user name and password");
                        return View();
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                    }
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}