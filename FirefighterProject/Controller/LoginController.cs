using System.Linq;
using FirefighterProject.Data;
using FirefighterProject.Model;

namespace FirefighterProject.Controller
{
    internal class LoginController
    {
        public bool IsLogin(string username, string password)
        {
            using (var db = new FirefighterDbContext())
            {
                var validAccount = db.Firefighters.FirstOrDefault(u => u.Username == username && u.Password == password);
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
