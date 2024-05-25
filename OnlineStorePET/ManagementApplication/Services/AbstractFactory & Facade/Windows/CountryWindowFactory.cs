using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.Services.Repositories.Proxy;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementApplication.MVVM.Views.Windows;
using ManagementApplication.MVVM.Views.Windows.CreateUpdate;

namespace ManagementApplication.Services.AbstractFactory___Facade.Windows
{
    public class CountryWindowFactory : IWindowFactory<Country>
    {
        public Window CreateWindow(ActionBaseVM<Country> viewModel)
        {
            return new CountryWindow(viewModel);
        }
    }
}