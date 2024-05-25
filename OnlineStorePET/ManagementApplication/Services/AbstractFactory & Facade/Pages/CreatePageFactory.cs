using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels;
using ManagementApplication.MVVM.Views.Pages;

namespace ManagementApplication.Services.AbstractFactory
{
    public class CreatePageFactory : IPageFactory
    {
        public Page CreatePage(ViewModelBase viewModel)
        {
            return new CreatePage(viewModel as CreatePageViewModel ?? throw new ArgumentException(nameof(viewModel)));
        }
    }
}
