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
        Login login;
        Registration registration;

        public View() { }

        public void Show()
        {
            login = new Login();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(login);
        }
    }
}
