using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.ColorVM;
using ManagementApplication.StaticFiles;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManagementApplication.MVVM.Views.WIndows.CreateUpdate
{
    /// <summary>
    /// Логика взаимодействия для ColorWindow.xaml
    /// </summary>
    public partial class ColorWindow
    {
        public ColorWindow(ActionBaseVM<StoreDataModels.Color> viewModel)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (viewModel is CreateColorViewModel)
            {
                this.DataContext = viewModel as CreateColorViewModel;
            }
            else if(viewModel is UpdateColorViewModel)
            {
                this.DataContext = viewModel as UpdateColorViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(viewModel));
            }
        }
    }
}
