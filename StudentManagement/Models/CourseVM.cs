﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models
{
    public class CourseVM
    {
        public int Id { get; set; }

        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string TeacherName { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        public Nullable<int> Space { get; set; }

    }
}