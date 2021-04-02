using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using StudentManagement.Api.Entities;

namespace StudentManagement.Api.Services
{
    public interface ICourseManagementService
    {
        void Add(Course course);

        int Update(Course course);

        Course GetById(int Id);

        void Delete(int id);

        List<Course> GetAll();

        PaginatedList<Course> GetAllCourses(int pageIndex, int pageSize);
    }
}
