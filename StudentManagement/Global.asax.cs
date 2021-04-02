using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Routing;
using System.Web.Optimization;
using StudentManagement.DataAccess.Context;
using StudentManagement.Infrastructure;

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
    }
}
