using ManagementApplication.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManagementApplication.Services.AbstractFactory___Facade
{
    public interface IPageFactoryFacade
    {
        Page GetRequiredPage<T>(ViewModelBase viewModel) where T : Page;
    }
}
