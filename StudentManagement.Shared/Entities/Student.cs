using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Api.Entities
{
    public class Student : IEntity
    {
        public Student()
        {
            Courses = new List<Course>();
        }


        [Key]
        [Column("StudentId")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string SurName { get; set; }

        [Required]
        [StringLength(15)]
        public string Gender { get; set; }

        public DateTime? DOB { get; set; }

        public AddressDetails Address { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }



    [ComplexType]
    public class AddressDetails
    {
        [Column("Address1")]
        public string Line1 { get; set; }
        [Column("Address2")]
        public string Line2 { get; set; }
        [Column("Address3")]
        public string Line3 { get; set; }
    }

   [NotMapped]
    public class CourseWithSpace
    {
        public int CourseId { get; set; }

        public string CourseCode { get; set; }

        public string CourseName { get; set; }

        public int Space { get; set; } 
        
        public int TotalRegisteredStudents { get; set; }
    }

    



}
