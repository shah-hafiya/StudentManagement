using Unity;
using System.Web.Mvc;
using Unity.AspNet.Mvc;
using Std.Services.IoCIntegrations;
using StudentManagement.DataAccess.IoCIntegrations;

namespace StudentManagement.Infrastructure
{
    public class UnityContainerConfiguration
    {
        public static void RegisterContainer()
        {
            var container = new UnityContainer();
            DataAccessDIIntegration.RegisterContainer(container);
            ServicesDIIntegration.RegisterService(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}