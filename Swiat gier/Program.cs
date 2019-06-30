using Swiat_gier.Model;
using Swiat_gier.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Swiat_gier
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IModel model = new TestModel();
            IView view = new View.View();
            Presenter.Presenter presenter = new Presenter.Presenter(model, view);
            presenter.RunApp();
        }
    }
}
