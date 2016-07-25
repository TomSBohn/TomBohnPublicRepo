using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Yes, you can actually set your own GPA.")]    
        //Had to make GPA a nullable type or else it auto-sets to 0.00M
        public decimal? GPA { get; set; }

        public Address Address { get; set; }

        //You have to go ALL the way to the most basic part to set a [Required]
        public Major Major { get; set; }

        public List<Course> Courses { get; set; }
    }
}