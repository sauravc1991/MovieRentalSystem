using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MRSApp.Models
{
    public class LoginData
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "UserName is Required")]
        public string Password { get; set; }
    }
}