using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace assignment2_validation.Models
{
    public class FormData
    {

    //private string Id;

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 to 50 letters")]
        [RegularExpression(@"^[a-zA-Z- .]+$", ErrorMessage = "Character not allowed")]
        public string name { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{2}-[0-9]{5}-[1-3]{1}$", ErrorMessage = "ID format: XX-XXXX-X")]

        public string id { get; set; }
        [Required]
        public string gender { get; set; }

        [Required]
        [EmailValidation("id")]
        public string email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Password must contain atleast 8 characters")]
        [RegularExpression(@"^.*(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#$ %^&*~><.,:;]).*$", ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special character")]
        public string password { get; set; }

        [Required]
        [Compare("password", ErrorMessage = "Password doesnt match")]
        public string confpassword { get; set; }

        [Required]
        [dobValidation()]
        public string dob { get; set; }

    }

}