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

namespace Swiat_gier
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public event Action<User> LogIn;
        public event Action OpenRegistration;

        private void button1_Click(object sender, EventArgs e)
        {
            ResetError();
            bool pass = true;
            if(NickTextBox.Text == "")
            {
                NickError.SetError(NickTextBox, "Nazwa uzytkownika jest wymagana");
                pass = false;
            }
            if(PassTextBox.Text == "")
            {
                PassError.SetError(PassTextBox, "Haslo jest wymagane");
                pass = false;
            }
            if (!pass)
                return;
            User user = new User();
            user.Nickname = NickTextBox.Text;
            user.Password = PassTextBox.Text;
            LogIn?.Invoke(user);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            OpenRegistration?.Invoke();
        }

        void ResetError()
        {
            NickError.Clear();
            PassError.Clear();
        }

        public void Reset()
        {
            NickTextBox.Text = "";
            PassTextBox.Text = "";
            ResetError();
        }
    }
}
