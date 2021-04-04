using System.Linq;
using System.Collections.Generic;
using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using StudentManagement.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;
using System;

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

        public PaginatedList<Student> GetAllStudents(string name, int pageIndex, int pageSize = 10)
        {
            Expression<Func<Student, bool>> predicate = null;

            if (!string.IsNullOrEmpty(name))
                predicate = (s) => s.FirstName.Equals(name);

            return studentRepository.Paginate(pageIndex, pageSize, x => x.Id, predicate);
        }

        public Student GetById(int Id)
        {
            Student data = studentRepository.GetSingle(Id);
            return data;
        }


        public void Update(Student student)
        {
            studentRepository.Edit(student);
        }
    }
}
