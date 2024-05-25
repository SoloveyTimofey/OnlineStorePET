using ManagementApplication.Models;
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
using ManagementApplication.StaticFiles;

namespace ManagementApplication.MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthenticationPage.xaml
    /// </summary>
    public partial class AuthenticationPage : Page
    {
        public AuthenticationPage(AuthenticationPageViewModel authorizationPageViewModel)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            this.DataContext = authorizationPageViewModel;
        }
    }
}
