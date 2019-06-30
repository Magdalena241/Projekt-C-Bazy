using Swiat_gier.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiat_gier.Model
{
    interface IModel
    {
        bool RegisterUser(User user);
        bool LogIn(User user);
        bool NickExist(string nick);
        bool MailExist(string mail);

        Dane GetCurrentUserData();
    }
}
