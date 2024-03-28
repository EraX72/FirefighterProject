using FirefighterProject.Data;
using FirefighterProject.Model;
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

             using (FirefighterDBEntities db = new FirefighterDBEntities())
             {
                 var validAccount = db.Firefighters.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
                 if (validAccount != null)
                 {
                     GlobalData.Id = validAccount.FirefighterID;
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
