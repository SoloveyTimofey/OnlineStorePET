using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.BrandVM;
using ManagementApplication.MVVM.ViewModels.Actions.CategoryVM;
using ManagementApplication.StaticFiles;
using StoreDataModels.Clothes;
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
    /// Логика взаимодействия для CategoryWindow.xaml
    /// </summary>
    public partial class CategoryWindow
    {
        public CategoryWindow(ActionBaseVM<ClothingCategory> viewModel)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (viewModel is CreateCategoryViewModel)
            {
                this.DataContext = viewModel as CreateCategoryViewModel;
            }
            else if (viewModel is UpdateCategoryViewModel)
            {
                this.DataContext = viewModel as UpdateCategoryViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(viewModel));
            }
        }
    }
}
