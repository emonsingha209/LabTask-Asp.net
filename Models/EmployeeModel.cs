using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginLabTask.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must be fill up")]
        [MinLength(3, ErrorMessage = "Must contain at least 3 characters")]
        [MaxLength(40, ErrorMessage = "More than 40 character is not allow")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Must be fill up")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOB { get; set; }
        [Required(ErrorMessage = "Must be fill up")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Must be fill up")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Enter a valid phone number")]
        public string PhoneNo { get; set; }
    }
}