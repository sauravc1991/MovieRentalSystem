using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSApp.Controllers
{
    public class ModifyController : Controller
    {
        MRSDataAccess.Repositories.UserRepositories userRepo = null;
       

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangeOfPassword(string newPassword)
        {
            userRepo = new MRSDataAccess.Repositories.UserRepositories();
            int uid = int.Parse(Session["UID"].ToString());          
            int stat=userRepo.ChangeUserPassword(uid,newPassword);
            if (stat == 1)
            {
                ViewBag.Status = "Password changed successfully";
            }
            else 
            {
                ViewBag.Status = "Password not changed";
            }
            return View(); 
        }

   }

}
