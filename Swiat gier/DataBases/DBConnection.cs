using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Swiat_gier.Data;

namespace Swiat_gier.DataBases
{
    class DBConnection
    {
        static string SERVER = "localhost";
        static string USER = "root";
        static string PASSWD = "Madzia24196";
        static string DATABASE = "swiat_gier";
        static uint PORT = 3306;

        private MySqlConnectionStringBuilder conStrBuilder;
        private MySqlConnection connection;
        private MySqlCommand command;
        public DBConnection()
        {
            conStrBuilder = new MySqlConnectionStringBuilder();
            conStrBuilder.Server = SERVER;
            conStrBuilder.UserID = USER;
            conStrBuilder.Password = PASSWD;
            conStrBuilder.Database = DATABASE;
            conStrBuilder.Port = PORT;
            conStrBuilder.SslMode = MySqlSslMode.None;
        }


        // zwraca false jeśli nie udało się dodać użytkownika
        public bool AddUser(User user)
        {
            connection = new MySqlConnection(conStrBuilder.ConnectionString);
            command = new MySqlCommand(Query.AddUser(user.Nickname, user.Password, user.Mail), connection);
            var command1 = new MySqlCommand(Query.GetUserList(), connection);
            try
            {
                connection.Open();

                MySqlDataReader dataReader = command1.ExecuteReader();
                while (dataReader.Read())
                {
                    if (dataReader[0].ToString() == user.Nickname)
                        return false;
                }

                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }

        // zwraca null jeśli nie ma użytkownika w bazie lub błędne hasło
        public User LogIn(string nickname, string password)
        {
            connection = new MySqlConnection(conStrBuilder.ConnectionString);
            command = new MySqlCommand(Query.GetUser(nickname, password), connection);
            User user = null;
            try
            {
                connection.Open();

                MySqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    string nick = dataReader[0].ToString();
                    string pass = dataReader[1].ToString();
                    string email = dataReader[3].ToString();
                    user = new User(nick, pass, email);
                }


            }
            catch (Exception exception)
            {
                return user;
            }
            finally
            {
                connection.Close();
            }
            return user;



        }

    }
}
