using StudentManagement.Api.Entities;
using System.Collections.Generic;

namespace StudentManagement.Api.Services
{
    public interface IStudentManagementService
    {
        IEnumerable<Student> Students { get; }
        PaginatedList<Student> GetAllStudents(int pageIndex, int pageSize);

        void Add(Student student);

        int Update(Student student);

        Student GetById(int Id);

        void Delete(int id);
    }
}
