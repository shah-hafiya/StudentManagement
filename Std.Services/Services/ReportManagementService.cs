using StudentManagement.Api.Entities;
using StudentManagement.DataAccess.Repositories.Interfaces;
using StudentManagement.Shared.Entities;
using StudentManagement.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Std.Services.Services
{
    public class ReportManagementService : IReportManagementService
    {
        private readonly IReportGeneratorRepository _reportrepository;
        public ReportManagementService(IReportGeneratorRepository reportGeneratorRepository)
        {
            _reportrepository = reportGeneratorRepository;
        }

        public List<CourseWithSpace> FetchCoursesWithSpace()
        {
            return _reportrepository.GetCourseWithSpaces();            
        }

        public List<RegisteredCourseStudent> FetchRegisteredCourseForStudent()
        {
            return _reportrepository.RegisteredCourseForStudent();
        }

        public List<StudentListForCourse> FetchStudentListForCourse()
        {
            return _reportrepository.StudentListForCourse();
        }

        public List<StudentNotRegisteredForMaxCourse> FetchStudentNotRegisteredForMaxCourse()
        {
            return _reportrepository.StudentNotRegisteredForMaxCourse();
        }
    }
}
