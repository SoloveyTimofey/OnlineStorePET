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
using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.CLothingVM;
using ManagementApplication.StaticFiles;
using StoreDataModels.Clothes;

namespace ManagementApplication.MVVM.Views.WIndows.CreateUpdate
{
    /// <summary>
    /// Логика взаимодействия для ClothingWindow.xaml
    /// </summary>
    public partial class ClothingWindow
    {
        public ClothingWindow(ActionBaseVM<Clothing> viewModel)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (viewModel is CreateClothingViewModel)
            {
                this.DataContext = viewModel as CreateClothingViewModel;
            }
            else if (viewModel is UpdateClothingViewModel)
            {
                this.DataContext = viewModel as UpdateClothingViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(viewModel));
            }
        }
    }
}
