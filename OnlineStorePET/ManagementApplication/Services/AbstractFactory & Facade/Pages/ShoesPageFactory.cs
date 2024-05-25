using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels;
using ManagementApplication.Services.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.MVVM.Views.Pages;
using System.Windows.Controls;

namespace ManagementApplication.Services.AbstractFactory___Facade
{
    public class ShoesPageFactory : IPageFactory
    {
        public Page CreatePage(ViewModelBase viewModel)
        {
            return new ShoesPage(viewModel as ShoesPageViewModel ?? throw new ArgumentException(nameof(viewModel)));
        }
    }
}
