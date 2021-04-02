using StudentManagement.Api.Entities;
using System.Collections.Generic;

namespace StudentManagement.Api.Services
{
    public interface IStudentManagementService
    {
        IEnumerable<Student> Students { get; }
        void Add(Student student);
    }
}
