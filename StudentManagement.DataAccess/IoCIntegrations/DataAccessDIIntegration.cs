using Unity;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.DataAccess.Repositories.Interfaces;

namespace StudentManagement.DataAccess.IoCIntegrations
{
    public class DataAccessDIIntegration
    {
        public static void RegisterContainer(UnityContainer container)
        {
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));

        }
    }
}
