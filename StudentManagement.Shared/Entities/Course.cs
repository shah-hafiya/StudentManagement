using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Api.Entities
{
    public class Course : IEntity
    {
        [Key]
        [Column("CourseId")]
        public int Id { get; set; }


        [Required]
        public string CourseCode { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public string TeacherName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public Nullable<int> Space { get; set; }

        public virtual ICollection<Student> Courses { get; set; }
    }
}