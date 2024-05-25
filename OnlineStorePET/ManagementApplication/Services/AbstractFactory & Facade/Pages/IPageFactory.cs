using ManagementApplication.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ManagementApplication.Services.AbstractFactory
{
    public interface IPageFactory
    {
        Page CreatePage(ViewModelBase viewModel);
    }
}
