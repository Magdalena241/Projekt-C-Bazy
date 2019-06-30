using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Swiat_gier.Data;

namespace Swiat_gier.Model
{
    class TestModel : IModel
    {
        List<User> users;
        User currentUser;

        public TestModel()
        {
            users = new List<User>();
        }

        public Dane GetCurrentUserData()
        {
            return new Dane();
        }

        public bool LogIn(User user)
        {
            currentUser = null;
            string password = getHashSha256(user.Password);
            foreach(var u in users)
            {
                if(user.Nickname == u.Nickname && password == u.Password)
                {
                    currentUser = u;
                    return true;
                }
            }
            return false;

        }

        public bool MailExist(string mail)
        {
            foreach(var u in users)
            {
                if (u.Mail == mail)
                    return true;
            }
            return false;
        }

        public bool NickExist(string nick)
        {
            foreach(var u in users)
            {
                if (u.Nickname == nick)
                    return true;
            }
            return false;
        }

        public bool RegisterUser(User user)
        {
            foreach(var u in users)
            {
                if (u.Nickname == user.Nickname || u.Mail == user.Mail)
                    return false;
            }
            user.Password = getHashSha256(user.Password);
            users.Add(user);
            return true;
        }

        private static string getHashSha256(string text)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
