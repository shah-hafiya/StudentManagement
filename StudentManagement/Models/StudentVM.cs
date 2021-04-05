using StudentManagement.Api.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class StudentCreateVM : StudentVM
    {
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter password")]
        public string Password { get; set; }
    }

    public class StudentVM
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        [Display(Name = "Sur Name")]
        public string SurName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Address Line1")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Address Line1")]
        public string Line1 { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Address Line2")]
        public string Line2 { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Address Line3")]
        public string Line3 { get; set; }

        public static Student ToStudent(StudentVM model)
        {
            return new Student
            {
                FirstName = model?.FirstName,
                SurName = model?.SurName,
                Gender = model?.Gender,
                DOB = model?.DOB,
                Address = new AddressDetails
                {
                    Line1 = model?.Line1,
                    Line2 = model?.Line2,
                    Line3 = model?.Line3
                }
            };
        }

        public static StudentVM ToStudentVM(Student model)
        {
            return new StudentVM
            {
                FirstName = model?.FirstName,
                SurName = model?.SurName,
                Gender = model?.Gender,
                DOB = model?.DOB,
                Line1 = model?.Address?.Line1,
                Line2 = model?.Address?.Line2,
                Line3 = model?.Address?.Line3
            };
        }
    }

    public enum Gender
    {
        Male,
        Female
    }
}