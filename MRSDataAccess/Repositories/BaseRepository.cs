using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRSDataAccess.Repositories
{
   public class BaseRepository
    {
       protected Entity.MovieRentalSystemEntities myDataContext;

       public BaseRepository()
       {
           myDataContext = new Entity.MovieRentalSystemEntities();
       }
       

       public string[] ValidateLogin(string name, string pwd)
       {
           var outRoleID = new System.Data.Objects.ObjectParameter("OutRoleId", typeof(int));
           var outUName = new System.Data.Objects.ObjectParameter("OutUName", typeof(string));
           var outUserID = new System.Data.Objects.ObjectParameter("OutUserID", typeof(int));
           myDataContext.AuthenticateUser(name,pwd,outRoleID,outUName,outUserID);
           string[] sessionArr = new string[3];
           var roleId = (int)outRoleID.Value;
           var UID = (int)outUserID.Value;
           var UName = outUName.Value.ToString();
           sessionArr[0] = roleId.ToString();
           sessionArr[1] = UName;
           sessionArr[2] = UID.ToString();
           return sessionArr;

       }

       public int RegisterUser(int roleID, string name, string username, string password, string phone, string email, string address)
       {
           int stat=myDataContext.InsertUser(roleID, name, username, password, phone, email, address);
           return stat;
                 
       }

       public List<MRSDataAccess.Entity.spTopTen_Result> DisplayTopTen() 
       {
           var top = myDataContext.spTopTen().ToList();
           return top;
       }
       }
    }

