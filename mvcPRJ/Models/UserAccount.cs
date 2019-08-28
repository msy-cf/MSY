using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvcPRJ.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required (ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-A]{2,3}|[0-9]{1,3})(\]?)$", ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required (ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Please confirm password.")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
    }
}