using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Api.Entities
{
    public class Student : IEntity
    {
        [Key]
        [Column("StudentId")]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string SurName { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        public DateTime? DOB { get; set; }

        public AddressDetails Address { get; set; }

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
}
