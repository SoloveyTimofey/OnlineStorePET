using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels.Actions;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApplication.Services.AbstractFactory___Facade.Windows
{
    public interface IWindowFactory<T> where T : IPrototype<T>
    {
        Window CreateWindow(ActionBaseVM<T> viewModel);
    }
}
