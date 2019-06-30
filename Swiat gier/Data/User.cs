using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiat_gier.Data
{
    public class User
    {

        public User(string nickname, string password, string mail)
        {
            Nickname = nickname;
            Password = password;
            Mail = mail;
        }

        public User(): this("", "", "")
        {
        }

        public string Nickname
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public string Mail
        {
            get; set;
        }
    }
}
