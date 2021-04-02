using Unity;
using Unity.Lifetime;
using System.Data.Entity;
using StudentManagement.DataAccess.Context;
using StudentManagement.DataAccess.Repositories;
using StudentManagement.DataAccess.Repositories.Interfaces;

namespace StudentManagement.DataAccess.IoCIntegrations
{
    public class DataAccessDIIntegration
    {
        public static void RegisterContainer(UnityContainer container)
        {
            container.RegisterType<DbContext, StudentManagementDbContext>(new ContainerControlledLifetimeManager());
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
