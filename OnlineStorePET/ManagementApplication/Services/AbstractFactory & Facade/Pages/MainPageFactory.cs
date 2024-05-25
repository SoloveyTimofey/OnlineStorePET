using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.MVVM.ViewModels;
using ManagementApplication.MVVM.Views.Pages;
using System.Windows.Controls;

namespace ManagementApplication.Services.AbstractFactory___Facade
{
    public class MainPageFactory : IPageFactory
    {
        public Page CreatePage(ViewModelBase viewModel)
        {
            return new MainPage(viewModel as MainPageViewModel ?? throw new ArgumentException(nameof(viewModel)));
        }
    }
}
