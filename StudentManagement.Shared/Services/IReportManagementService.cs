using StudentManagement.Api.Entities;
using StudentManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Shared.Services
{
    public interface IReportManagementService
    {
        List<CourseWithSpace> FetchCoursesWithSpace();
        List<RegisteredCourseStudent> FetchRegisteredCourseForStudent();
        List<StudentListForCourse> FetchStudentListForCourse();
        List<StudentNotRegisteredForMaxCourse> FetchStudentNotRegisteredForMaxCourse();
    }
}
