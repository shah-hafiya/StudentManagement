using StudentManagement.Api.Entities;
using StudentManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DataAccess.Repositories.Interfaces
{
    public interface IReportGeneratorRepository
    {
        List<CourseWithSpace> GetCourseWithSpaces();
        List<RegisteredCourseStudent> RegisteredCourseForStudent();
        List<StudentListForCourse> StudentListForCourse();

        List<StudentNotRegisteredForMaxCourse> StudentNotRegisteredForMaxCourse();

    }
}
