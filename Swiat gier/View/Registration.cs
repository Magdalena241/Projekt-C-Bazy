using Swiat_gier.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Swiat_gier
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        public event Action OpenLogIn;
        public event Action<User> RegisterUser;

        public void RegistrationError(bool NickExists, bool MailExist)
        {
            if (NickExists)
            {
                NickError.SetError(NickTextBox, "Istnieje juz konto o podanej nazwie uzytkownika");
            }
            if(MailExist)
            {
                EmailError.SetError(EmailTextBox, "Istnieje juz konto o podanym adresie email");
            }
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            ResetError();
            bool pass = true;
            if(PassTextBox.Text.Length < 6)
            {
                PassError.SetError(PassTextBox, "Haslo musi miec dlugosc przynajmniej 6 znakow");
                pass = false;
            }
            if(!IsValidEmail(EmailTextBox.Text))
            {
                EmailError.SetError(EmailTextBox, "Blednie podany adres email");
                pass = false;
            }
            if (NickTextBox.Text.Length < 4)
            {
                NickError.SetError(NickTextBox, "Nazwa uzytkownika musi miec dlugosc przynajmniej 5 znakow");
                pass = false;
            }
            if (!pass)
                return;
            
            User user = new User();
            user.Nickname = NickTextBox.Text;
            user.Mail = EmailTextBox.Text;
            user.Password = PassTextBox.Text;
            RegisterUser?.Invoke(user);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OpenLogIn?.Invoke();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void ResetError()
        {
            EmailError.Clear();
            PassError.Clear();
            NickError.Clear();
        }
    }
}
