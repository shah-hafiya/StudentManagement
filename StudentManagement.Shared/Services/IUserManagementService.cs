using StudentManagement.Api.Entities;
using System.Collections.Generic;

namespace StudentManagement.Api.Services
{
    public interface IUserManagementService
    {
        IEnumerable<Student> Students { get; }

        void Add(Student student);
    }
}
