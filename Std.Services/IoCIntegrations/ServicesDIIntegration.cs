using Unity;
using Std.Services.Services;
using StudentManagement.Api.Services;
using StudentManagement.Shared.Services;

namespace Std.Services.IoCIntegrations
{
    public class ServicesDIIntegration
    {
        public static void RegisterService(UnityContainer container)
        {
            container.RegisterType<IUserManagementService, UsermanagementService>();
            container.RegisterType<IStudentManagementService, StudentManagementService>();
            container.RegisterType<ICourseManagementService, CourseManagementService>();
            container.RegisterType<IReportManagementService, ReportManagementService>();
        }
    }
}
