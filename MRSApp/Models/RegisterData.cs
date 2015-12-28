using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace MRSApp.Models
{
    public class RegisterData
    {
        
        public int RoleID { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [StringLength(50)]
        [Display(Name = "Name: ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        [StringLength(50)]
        [Display(Name = "UserName: ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Password: ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Phone no is Required")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, MinimumLength = 10)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",ErrorMessage=" Provide a Valid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
      

    }
}