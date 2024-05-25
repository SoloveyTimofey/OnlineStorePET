using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.Views.WIndows.CreateUpdate;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApplication.Services.AbstractFactory___Facade.Windows
{
    public class ColorWindowFactory : IWindowFactory<Color>
    {
        public Window CreateWindow(ActionBaseVM<Color> viewModel)
        {
            return new ColorWindow(viewModel);
        }
    }
}
