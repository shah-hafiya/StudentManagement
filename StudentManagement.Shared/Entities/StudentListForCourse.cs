using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Shared.Entities
{
    public class StudentListForCourse
    {
        //c.CourseCode, c.CourseName, s.FirstName, s.SurName
        public string FirstName { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string SurName { get; set; }
    }
}
