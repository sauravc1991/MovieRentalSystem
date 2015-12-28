using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using MRSApp.Models;

namespace MRSApp.Controllers
{ 
    public class HomeController : Controller
    {
       
        public ActionResult Index()
        {
            Session["RoleID"] = "0";
            Session["UserName"] = " ";
            Session["UID"] = "0";
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginData dataObj)
        {
                MRSDataAccess.Repositories.BaseRepository baseRepo = new MRSDataAccess.Repositories.BaseRepository();
                var res=baseRepo.ValidateLogin(dataObj.UserID,dataObj.Password);
            if(ModelState.IsValid)
            {
                int RoleId=Convert.ToInt32(res[0]);
                if (RoleId==1)
                {
                    Session["RoleID"] = res[0];
                    Session["UserName"]= res[1];
                    Session["UID"] = res[2];
                    return RedirectToAction("CustomerPage");
                }
                else if (RoleId == 2)
                {
                    Session["RoleID"] = res[0];
                    Session["UserName"] = res[1];
                    Session["UID"] = res[2];
                    return RedirectToAction("AdminPage");
                }
                else
                {                   
                    ViewBag.LoginStatus = "Username/password Not valid";
                    return View();
                }
            }
            return View();
            }
               
                    public ActionResult NewUserReg() 
                {
                    return View();
                }

                [HttpPost]
                public ActionResult CreateUser(MRSApp.Models.RegisterData regObj)
                {
                    int flag = 0;
                    if (ModelState.IsValid)
                    {
                        string name = regObj.Name;
                        string username = regObj.UserName;
                        string password = regObj.Password;
                        string phone = regObj.Phone;
                        string email = regObj.Email;
                        string address = regObj.Address;
                        int roleID = 1;
                        
                        MRSDataAccess.Repositories.BaseRepository baseRepoReg = new MRSDataAccess.Repositories.BaseRepository();
                        flag = baseRepoReg.RegisterUser(roleID, name, username, password, phone, email, address);
                    }
                    if (flag == 1)
                    {
                        ViewBag.RegisterStatus = "Registration Successfull";
                        return View();
                    }
                    else
                    {
                        ViewBag.RegisterStatus = "Registration Unuccessfull";
                        return View();
                    }
                }

                public ActionResult DisplayTop()
                {
                    MRSDataAccess.Repositories.BaseRepository obj1 = new MRSDataAccess.Repositories.BaseRepository();             
                    MRSApp.ViewModels.TopTenMoviesViewModel topTen = null;
                    List<MRSApp.ViewModels.TopTenMoviesViewModel> topTenList = new List<ViewModels.TopTenMoviesViewModel>();
                    foreach (var item in obj1.DisplayTopTen())
                    {
                        topTen = new ViewModels.TopTenMoviesViewModel();
                        topTen.MovieName = item.MovieName;
                        topTen.Rating = item.Rating;
                        topTenList.Add(topTen);
                    }
                    return View(topTenList);
                }

                [HttpPost]
                public ActionResult SearchMovieByName(MRSApp.Models.MovieData mdata)
                {
                    MRSDataAccess.Entity.MovieRentalSystemEntities searchmovie = new MRSDataAccess.Entity.MovieRentalSystemEntities();
                    var moviebyname = searchmovie.MovieInformations.Single(m =>m.MovieName==mdata.MovieName);
                    IEnumerable<MRSDataAccess.Entity.MovieInformation> movies = searchmovie.MovieInformations.Where(m => m.MovieName.StartsWith(mdata.MovieName));
                    return View(movies);
                }


                public ActionResult AdminPage()
                {
                     return View();
                }

                public ActionResult CustomerPage()
                {
                    return View();
                }

                public ActionResult LogOut()
                {
                    Session.Abandon();
                    return RedirectToAction("Index", "Home");

                }

                public ActionResult ContactUs()
                {
                    return View();
                }

                public ActionResult HomeView()
                {
                    Session["RoleID"] = "0";
                    Session["UserName"] = " ";
                    Session["UID"] = "0";
                    return View();
                }
          }
     }

