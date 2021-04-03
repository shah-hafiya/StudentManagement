using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Routing;
using System.Web.Optimization;
using StudentManagement.Models;
using System.Security.Principal;
using StudentManagement.Infrastructure;
using StudentManagement.DataAccess.Context;

namespace StudentManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityContainerConfiguration.RegisterContainer();

            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentManagementDbContext>());
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs args)
        {
            if (Context.User != null)
            {
                var name = Context.User.Identity.Name;

                if (Admin.FakeNames.Any(x => x.Equals(name, StringComparison.OrdinalIgnoreCase)))
                {
                    GenericPrincipal genericPrincipal = new GenericPrincipal(Context.User.Identity, new string[] { "Admin" });
                    Context.User = genericPrincipal;
                }
                else
                {
                    GenericPrincipal genericPrincipal = new GenericPrincipal(Context.User.Identity, new string[] { "Student" });
                    Context.User = genericPrincipal;
                }
            }
        }
    }
}
