using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MRSApp.Models
{
    public class UserProfile
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}