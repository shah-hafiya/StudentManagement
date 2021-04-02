using StudentManagement.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Api.Services
{
    public interface ICourseManagementService
    {
        void Add(Course course);

        int Update(Course course);

        Course GetById(int Id);

        void Delete(int id);

        List<Course> GetAll();





    }
}
