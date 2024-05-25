using ManagementApplication.MVVM.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManagementApplication.MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            SetDictionaries();

            InitializeComponent();

            this.DataContext = mainPageViewModel;
        }

        private void SetDictionaries()
        {
            var resouseDict1 = new ResourceDictionary();
            resouseDict1.Source = new Uri(@"..\..\..\Themes\Colors.xaml", UriKind.RelativeOrAbsolute);
            var resouseDict2 = new ResourceDictionary();
            resouseDict2.Source = new Uri(@"..\..\..\Themes\CustomStyles.xaml", UriKind.RelativeOrAbsolute);
            this.Resources.MergedDictionaries.Add(resouseDict1);
            this.Resources.MergedDictionaries.Add(resouseDict2);
        }
    }
}
