using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using StudentManagement.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Std.Services.Services
{
    public class UsermanagementService : IUserManagementService
    {
        private readonly IRepository<Student> studentRepository;

        public UsermanagementService(IRepository<Student> studentRepository)
        {
            this.studentRepository = studentRepository;
        }

        public IEnumerable<Student> Students => studentRepository.Get().ToList();

        public void Add(Student student)
        {
            studentRepository.Add(student);
            
        }

        



    }
}
