using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using StudentManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Linq;

namespace Std.Services.Services
{
    public class UsermanagementService : IUserManagementService
    {
        private readonly IRepository<Student> stdRepo;

        public UsermanagementService(IRepository<Student> stdRepo)
        {
            this.stdRepo = stdRepo;
        }

        public UserInfo GetUserInfo(string username, string password)
        {
            var user = stdRepo.FindBy(s => s.FirstName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && s.Password == password).FirstOrDefault();

            if (user != null)
                return new UserInfo
                {
                    Name = user.FirstName
                };

            return null;
        }
    }
}
