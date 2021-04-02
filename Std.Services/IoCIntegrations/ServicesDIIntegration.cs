using Unity;
using Std.Services.Services;
using StudentManagement.Api.Services;

namespace Std.Services.IoCIntegrations
{
    public class ServicesDIIntegration
    {
        public static void RegisterService(UnityContainer container)
        {
            container.RegisterType<IUserManagementService, UsermanagementService>();
            container.RegisterType<ICourseManagementService, CourseManagementService>();

        }
    }
}
