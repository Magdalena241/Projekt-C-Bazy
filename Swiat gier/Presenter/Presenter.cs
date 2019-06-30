using Swiat_gier.Model;
using Swiat_gier.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swiat_gier.Presenter
{
    class Presenter
    {
        IModel model;
        IView view;

        public Presenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public void RunApp()
        {
            view.Show();
        }
    }
}
