using StudentManagement.Api.Entities;
using System.Collections.Generic;

namespace StudentManagement.Api.Services
{
    public interface IUserManagementService
    {
        UserInfo GetUserInfo(string username, string password);
    }

    public class UserInfo
    {
        public string Name { get; set; }
    }
}
