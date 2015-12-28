using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MRSApp.Controllers
{
    public class CheckController : Controller
    {
       public ActionResult Index()
        {
            return View();
        }

       
       public ActionResult CheckIn()
       {
           var req = Request.Form["UID"];
           int UserID = int.Parse(req);
           MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
           List<MRSDataAccess.Entity.MovieTransact> tbl = db.MovieTransacts.Where(u => u.UID == UserID && u.Status.Equals("RESERVED")).ToList();
           return View(tbl);
       }


      
       public ActionResult CheckInConfirm()
       {
           int CheckInStatus = 0;
           MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
           int rid = int.Parse(Request.QueryString["rid"]);
           CheckInStatus = db.CheckIn(rid);
           if (CheckInStatus == 1)
           {
               ViewBag.Status = "Check-In Successfull";
           }
           else
           {
               ViewBag.Status = "Check-In Unsuccessfull";
           }
           return View();

       }

       public ActionResult CheckOutHome()
       {
           return View();
       }

       public ActionResult CheckOut()
       {
           var req = Request.Form["UID"];
           int UserID = int.Parse(req);
           MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
           List<MRSDataAccess.Entity.MovieTransact> tbl = db.MovieTransacts.Where(u => u.UID == UserID && u.Status.Equals("ISSUED")).ToList();
           return View(tbl); 
       }

       public ActionResult CheckOutConfirm()
       {
           int CheckOutStatus = 0;
           MRSDataAccess.Entity.MovieRentalSystemEntities db = new MRSDataAccess.Entity.MovieRentalSystemEntities();
           int rid = int.Parse(Request.QueryString["rid"]);
           CheckOutStatus = db.CheckOut(rid);
           if (CheckOutStatus == 2)
           {
               ViewBag.Status = "Check-Out Successfull";
           }
           else
           {
               ViewBag.Status = "Check-Out Unsuccessfull";
           }
           return View();
       }

    }
}
