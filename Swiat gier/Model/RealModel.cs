using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swiat_gier.Data;

namespace Swiat_gier.Model
{
    class RealModel : IModel
    {
        public event Action LogInFailed;

        public Dane GetCurrentUserData()
        {
            throw new NotImplementedException();
        }

        public bool LogIn(User user)
        {
            throw new NotImplementedException();
        }

        public bool MailExist(string mail)
        {
            throw new NotImplementedException();
        }

        public bool NickExist(string nick)
        {
            throw new NotImplementedException();
        }

        public bool RegisterUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
