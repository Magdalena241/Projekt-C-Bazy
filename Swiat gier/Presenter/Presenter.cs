using Swiat_gier.Data;
using Swiat_gier.Model;
using Swiat_gier.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiat_gier.Presenter
{
    class Presenter
    {
        IModel model;
        IView view;

        public Presenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            Init();
        }

        public void RunApp()
        {
            view.Show();
        }

        private void Init()
        {
            view.LogIn += logIn;
            view.RegisterUser += registerUser;
        }

        void logIn(User user)
        {
            bool pass = model.LogIn(user);
            if (pass)
            {
                Dane data = model.GetCurrentUserData();
                view.PassLogIn(data) ;
            }
            else
            {
                view.LogInFailed();
            }

        }

        void registerUser(User user)
        {
            bool pass = model.RegisterUser(user);
            if (pass)
            {
                view.RegistrationSucces();
            }
            else
            {
                bool n = model.NickExist(user.Nickname);
                bool m = model.MailExist(user.Mail);
                view.RegistrationError(n, m);
            }
        }


    }
}
