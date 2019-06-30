using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiat_gier.Data;

namespace Swiat_gier.View
{
    interface IView
    {
        event Action<User> LogIn;
        event Action<User> RegisterUser;

        void Show();

        void LogInFailed();

        void RegistrationSucces();

        void RegistrationError(bool NickExist, bool MailExist);

        void PassLogIn(Dane data);
    }
}
