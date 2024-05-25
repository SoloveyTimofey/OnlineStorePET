using ManagementApplication.MVVM.ViewModels.Actions;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementApplication.MVVM.Views.WIndows;
using ManagementApplication.MVVM.Views.WIndows.CreateUpdate;

namespace ManagementApplication.Services.AbstractFactory___Facade.Windows
{
    public class SleeveLenghtWindowFactory : IWindowFactory<SleeveLenght>
    {
        public Window CreateWindow(ActionBaseVM<SleeveLenght> viewModel)
        {
            return new SleeveLenghtWindow(viewModel);
        }
    }
}
