using BookKeeperNewJosh.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookKeeperNewJosh.Models
{
    public class UserSignIn

    {
        [Key]
        [Display(Name = "Student Number")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Your student number is required")]
        public int studentNo { get; set; }
        
        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your first name")]
        public string fName { get; set; }
        
        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your last name")]
        public string lName { get; set; }
        
        [Display(Name = "Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Your password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters are required")]
        public string password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="These two passwords do not match")]
        [MinLength(6, ErrorMessage = "Minimum 6 characters are required")]
        public string confirmpassword { get; set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Your Email address is required")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public int totalrating { get; set; }
        public int ratingcount { get; set; }
        public bool RememberMe { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}