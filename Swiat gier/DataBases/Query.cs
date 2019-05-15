using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiat_gier.DataBases
{
    static class Query
    {
        static string ADD_USER_QUERY = "insert user(nickname, haslo, mail) values({0}, {1}, {2})";
        static string CHANGE_AVATAR = "update user set avatar = {0} where nickname = {1}" ;
        static string CHANGE_PASSWORD = "update user set haslo = {0} where nickname = {1}";
        static string ADD_LIKE = "insert user_gra_like values({1}, {2})" ;
        static string ADD_COMMENT = "insert user_gra_kom values({1}, {2}, {3})";
        static string ADD_RATE = "insert user_gra_ocena values({1}, {2}, {3})";
        static string GET_PASSWORD = "select haslo from user where nickname = {0}";
        static string GET_USER_LIST = "select nickname from user";
        static string GET_USER = "select * from user where nickname = {0} and haslo = {1}";
       



        public static string AddUser(string nickname, string password, string mail)
        {
            return String.Format(ADD_USER_QUERY, nickname, password, mail);
        }

        public static string ChangePassword(string newPassword, string nickname)
        {
            return String.Format(CHANGE_PASSWORD, newPassword, nickname);

        }

        public static string AddToFavourite(string nickname, string gameID)
        {
            return String.Format(ADD_LIKE, nickname, gameID);

        }
        public static string AddComment(string nickname, string gameID, string comment)
        {
            return String.Format(ADD_COMMENT, nickname, gameID, comment);

        }
        public static string AddRate(string nickname, string gameID, string rate)
        {
            return String.Format(ADD_RATE, nickname, gameID, rate);

        }
        public static string GetPassword(string nickname)
        {
            return String.Format(GET_PASSWORD, nickname);
        }
     
        public static string GetUserList()
        {
            return String.Format(GET_USER_LIST);
        }

        public static string GetUser(string nickname, string password)
        {
            return String.Format(GET_USER, nickname, password);
        }
    }

}
