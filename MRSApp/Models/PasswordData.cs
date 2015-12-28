using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MRSApp.Models
{
    public class PasswordData
    {
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 5)]
        public string NewPassword { get; set; }
       
    }
}