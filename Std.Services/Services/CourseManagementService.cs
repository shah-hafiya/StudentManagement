using System.Linq;
using System.Collections.Generic;
using StudentManagement.Api.Entities;
using StudentManagement.Api.Services;
using StudentManagement.DataAccess.Repositories.Interfaces;
using System.Linq.Expressions;
using System;

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
            Course coursedata = _courseRepository.GetSingle(course.Id);
            coursedata.Space = course.Space;
            coursedata.StartDate = course.StartDate;
            coursedata.EndDate = course.EndDate;
            coursedata.CourseCode = course.CourseCode;
            coursedata.CourseName = course.CourseName;
            coursedata.TeacherName = course.TeacherName;
            _courseRepository.Edit(coursedata);
            return coursedata.Id;
        }

        public Course GetById(int Id)
        {
            Course courseres = _courseRepository.GetSingle(Id);
            return courseres;
        }

        public void Delete(int id)
        {
            Course coursedata = _courseRepository.GetSingle(id);
            _courseRepository.Delete(coursedata);
        }

        public List<Course> GetAll()
        {
            List<Course> courselist = _courseRepository.GetAll().ToList();
            return courselist;
        }

        public PaginatedList<Course> GetAllCourses(int pageIndex, int pageSize)
        {
            return _courseRepository.Paginate(pageIndex, pageSize, x => x.Id);
        }
    }
}
