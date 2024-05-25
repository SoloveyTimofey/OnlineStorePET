using MahApps.Metro.Controls.Dialogs;
using ManagementApplication.MVVM.ViewModels.Actions;
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

namespace ManagementApplication.MVVM.Views.Windows.CreateUpdate
{
    /// <summary>
    /// Логика взаимодействия для CountryWindow.xaml
    /// </summary>
    public partial class CountryWindow
    {
        public CountryWindow(ActionBaseVM<Country> actionCountryVM)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (actionCountryVM is CreateCountryViewModel)
            {
                this.DataContext = actionCountryVM as CreateCountryViewModel;
            }
            else if(actionCountryVM is UpdateCountryViewModel)
            {
                this.DataContext = actionCountryVM as UpdateCountryViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(actionCountryVM));
            }
        }
    }
}
