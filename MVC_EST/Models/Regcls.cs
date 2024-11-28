using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_EST.Models
{
    public class Regcls
    {
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 100, ErrorMessage = "Age must be between 18 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date Format")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must be 10 digits")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters long.")]
        public string Password { get; set; }

        // Qualification details
        public List<QualificationViewModel> Qualifications { get; set; }

    }
    public class QualificationViewModel
    {
        [Required(ErrorMessage = "Course Name is required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Percentage is required")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        public decimal Percentage { get; set; }

        [Required(ErrorMessage = "Year of Passing is required")]
        [Range(1900, 2100, ErrorMessage = "Please enter a valid year")]
        public int YearOfPassing { get; set; }
    }
}