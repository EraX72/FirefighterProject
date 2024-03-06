using FirefighterProject.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterProject.Controller
{
    internal class LoginController
    {
        public bool IsLogin(string username, string password)
        {
            //ToDo!!!!!!!!!!!

            using (FirefighterDbContext db = new FirefighterDbContext())
            {
                var validAccount = db.User.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
                if (validAccount != null)
                {
                    GlobalData.Id = validAccount.Id;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
