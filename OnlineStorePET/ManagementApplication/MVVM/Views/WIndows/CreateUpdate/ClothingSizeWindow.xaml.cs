using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.ColorVM;
using ManagementApplication.MVVM.ViewModels.Actions.ClothingSizeVM;
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
    /// Логика взаимодействия для ClothingSizeWindow.xaml
    /// </summary>
    public partial class ClothingSizeWindow
    {
        public ClothingSizeWindow(ActionBaseVM<ClothingSize> viewModel)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (viewModel is CreateClothingSizeViewModel)
            {
                this.DataContext = viewModel as CreateClothingSizeViewModel;
            }
            else if (viewModel is UpdateClothingSizeViewModel)
            {
                this.DataContext = viewModel as UpdateClothingSizeViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(viewModel));
            }
        }
    }
}
