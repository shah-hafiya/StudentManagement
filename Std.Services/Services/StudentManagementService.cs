using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using StudentManagement.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Std.Services.Services
{
    public class StudentManagementService : IStudentManagementService
    {
        private readonly IRepository<Student> studentRepository;

        public StudentManagementService(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IEnumerable<Student> Students => studentRepository.GetAll().ToList();

        public void Add(Student student)
        {
            studentRepository.Add(student);
        }

        public void Delete(int id)
        {
            Student data = studentRepository.GetSingle(id);
            studentRepository.Delete(data);
        }

        public PaginatedList<Student> GetAllStudents(int pageIndex, int pageSize = 10)
        {
            return studentRepository.Paginate(pageIndex, pageSize, x => x.Id);
        }

        public Student GetById(int Id)
        {
            Student data = studentRepository.GetSingle(Id);
            return data;
        }


        public int Update(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
