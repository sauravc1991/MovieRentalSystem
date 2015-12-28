using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MRSDataAccess.Repositories
{  

    public class UserRepositories:BaseRepository
    {
        public IEnumerable<Entity.User> GetAllUsers()
        {
            IEnumerable<Entity.User> allUsers = myDataContext.Users.OrderBy(u => u.Name).Where(u => u.RoleID == 1);
            return allUsers;
        }

        //public void ViewUserProfile(int uid)
        //{
        //    var outUsername = new System.Data.Objects.ObjectParameter("outUsername", typeof(string));
        //    var outName = new System.Data.Objects.ObjectParameter("outName", typeof(string));
        //    var outPhone = new System.Data.Objects.ObjectParameter("outPhone", typeof(string));
        //    var outEmail = new System.Data.Objects.ObjectParameter("outEmail", typeof(string));
        //    var outAddress = new System.Data.Objects.ObjectParameter("outAddress", typeof(string));
        //    myDataContext.UserViewProfile(uid, outUsername, outName, outPhone, outPhone, outAddress);         
        //}

        public IEnumerable<MRSDataAccess.Entity.User> ViewUserProfile(int uid)
        {
            IEnumerable<Entity.User> allUsers = myDataContext.Users.OrderBy(e => e.Name).Where(u=>u.UID==uid);
            return allUsers;
        }

        public int ChangeUserPassword(int uid, string password) 
        {
            int stat=myDataContext.ChangePassword(uid, password);
            return stat;
        }
        

       
    }
}
