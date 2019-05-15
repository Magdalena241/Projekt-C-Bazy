using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiat_gier.Data
{
    class User
    {
        string nickname;
        string password;
        string mail;

        public User(string nickname, string password, string mail)
        {
            this.nickname = nickname;
            this.password = password;
            this.mail = mail;
        }

        public string Nickname
        {
            get
            {
                return nickname;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
        }
        public string Mail
        {
            get
            {
                return mail;
            }
        }
    }
}
