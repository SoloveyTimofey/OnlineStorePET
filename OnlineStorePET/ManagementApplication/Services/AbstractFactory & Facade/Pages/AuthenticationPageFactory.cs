using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.MVVM.Views.Pages;
using ManagementApplication.MVVM.ViewModels;
using System.Windows.Controls;
using System.ComponentModel;
using ManagementApplication.MVVM.Core;

namespace ManagementApplication.Services.AbstractFactory
{
    public class AuthenticationPageFactory : IPageFactory
    {
        public Page CreatePage(ViewModelBase viewModel)
        {
            return new AuthenticationPage(viewModel as AuthenticationPageViewModel ?? throw new ArgumentException(nameof(viewModel)));
        }
    }
}
