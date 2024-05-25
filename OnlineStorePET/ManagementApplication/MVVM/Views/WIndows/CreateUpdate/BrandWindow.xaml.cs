using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.BrandVM;
using ManagementApplication.MVVM.ViewModels.Actions.CountryVM;
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
    /// Логика взаимодействия для BrandWindow.xaml
    /// </summary>
    public partial class BrandWindow 
    {
        public BrandWindow(ActionBaseVM<Brand> viewModel)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (viewModel is CreateBrandViewModel)
            {
                this.DataContext = viewModel as CreateBrandViewModel;
            }
            else if (viewModel is UpdateBrandViewModel)
            {
                this.DataContext = viewModel as UpdateBrandViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(viewModel));
            }
        }
    }
}
