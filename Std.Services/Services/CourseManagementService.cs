using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using StudentManagement.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.Services.Services
{
    public class CourseManagementService : ICourseManagementService
    {
        private readonly IRepository<Course> _courseRepository;

        public CourseManagementService(IRepository<Course> courseRepository)
        {
            this._courseRepository = courseRepository;
        }

        public void Add(Course course)
        {
            _courseRepository.Add(course);
            
        }     

        public int Update(Course course)
        {
            Course coursedata = _courseRepository.GetById(course.Id);
            coursedata.Space = course.Space;
            coursedata.StartDate = course.StartDate;
            coursedata.EndDate = course.EndDate;
            coursedata.CourseCode = course.CourseCode;
            coursedata.CourseName = course.CourseName;
            coursedata.TeacherName = course.TeacherName;
            _courseRepository.Update(coursedata);
            return coursedata.Id;
        }

        public Course GetById(int Id)
        {
            Course courseres = _courseRepository.GetById(Id);
            return courseres;
        }

        public void Delete(int id)
        {
            _courseRepository.Delete(id);
        }

        public List<Course> GetAll()
        {
            List<Course> courselist = _courseRepository.Get().ToList();
            return courselist;

        }
    }
}
