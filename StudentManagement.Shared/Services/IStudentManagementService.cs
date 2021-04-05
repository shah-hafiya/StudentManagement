using StudentManagement.Api.Entities;
using System.Collections.Generic;

namespace StudentManagement.Api.Services
{
    public interface IStudentManagementService
    {
        IEnumerable<Student> Students { get; }
        PaginatedList<Student> GetAllStudents(string name, int pageIndex, int pageSize = 10);


        void Add(Student student);

        void Update(Student student);

        Student GetById(int Id);

        void Delete(int id);
    }
}
