using Hoc_ASP.NET_MVC.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hoc_ASP.NET_MVC.Models.DAO
{
    public class AccountDAO
    {
        private Context db;

        public AccountDAO()
        {
            db = new Context();
        }
        public bool Login(Account user)
        {
            int count = db.Accounts.Count(a => a.nameLogin == user.nameLogin && a.passWord == user.passWord);
            if (count > 0) 
                return true;
            else 
                return false;
        }
    }
}