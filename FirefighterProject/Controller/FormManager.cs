using FirefighterProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirefighterProject.Controller
{
    internal class FormManager
    {
        private static LoginView loginForm;
        private static RegisterView registerForm;

        public static void ShowLoginForm()
        {
            if (loginForm == null || loginForm.IsDisposed)
            {
                loginForm = new LoginView();
                loginForm.Show();
            }
            else
            {
                loginForm.Show();
            }
        }

        public static void ShowRegisterForm()
        {
            if (registerForm == null || registerForm.IsDisposed)
            {
                registerForm = new RegisterView(loginForm);
                registerForm.Show();
            }
            else
            {
                registerForm.Show();
            }
        }

        public static void CloseRegisterForm()
        {
            registerForm?.Close();
        }
    }
}

