using Swiat_gier.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swiat_gier.View
{
    class View : IView
    {
        Registration registration;
        Login login;

        public event Action<User> LogIn;
        public event Action<User> RegisterUser;


        public View()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            login = new Login();
            login.LogIn += logIn;
            login.OpenRegistration += OpenRegistrationForm;
        }      

        public void LogInFailed()
        {
            MessageBox.Show("Uzytkownik nie istnieje lub haslo jest nie poprawne ", "Blad logowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Show()
        {
            Application.Run(login);
        }

        void OpenRegistrationForm()
        {
            registration = new Registration();
            registration.OpenLogIn += CloseRegistration;
            registration.RegisterUser += registerUser;
            login.Hide();
            registration.Show();
        }

        void logIn(User user)
        {
            LogIn?.Invoke(user);
        }

        private void CloseRegistration()
        {
            registration.Close();
            registration = null;
            login.Reset();
            login.Show();
        }

        public void RegistrationSucces()
        {
            MessageBox.Show("Konto zostalo utworzone.\n\r Nacisnij OK, aby powrocic do okna logowania.", "Rejestracja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CloseRegistration();
        }

        void registerUser(User user)
        {
            RegisterUser?.Invoke(user);
        }

        public void RegistrationError(bool NickExist, bool MailExist)
        {
            registration.RegistrationError(NickExist, MailExist);
        }

        public void PassLogIn(Dane data)
        {
            throw new NotImplementedException();
        }
    }
}
