using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ManagementApplication.MVVM.Views.Pages;
using System.Threading.Tasks;
using System.Windows.Controls;
using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels;

namespace ManagementApplication.Services.AbstractFactory
{
    public class ClothesPageFactory : IPageFactory
    {
        public Page CreatePage(ViewModelBase viewModel)
        {
            return new ClothesPage(viewModel as ClothesPageViewModel ?? throw new ArgumentException(nameof(viewModel)));
        }
    }
}
