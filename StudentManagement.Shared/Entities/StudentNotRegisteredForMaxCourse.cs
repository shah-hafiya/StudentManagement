using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Shared.Entities
{
    public class StudentNotRegisteredForMaxCourse
    {
        //s.StudentId, s.FirstName, Count( c.CourseId) as [No of CoursesEnrolled]
        public string FirstName { get; set; }
        public int StudentId { get; set; }
        
        public int CoursesEnrolled { get; set; }
    }
}
