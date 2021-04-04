using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Shared.Entities
{
    public class RegisteredCourseStudent
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public int NoOfRegisteredCourses { get; set; }
    }
}
