using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels.Actions;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ManagementApplication.Services.AbstractFactory___Facade.Windows
{
    public interface IWindowFactoryFacade
    {
        Window GetRequiredWindow<T>(ViewModelBase viewModel) where T : Window;
    }
}
