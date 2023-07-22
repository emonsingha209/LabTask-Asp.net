using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoginLabTask.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must be fill up")]
        [MinLength(3, ErrorMessage = "Must contain at least 3 characters")]
        [MaxLength(40, ErrorMessage = "More than 40 character is not allow")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }

    }
}