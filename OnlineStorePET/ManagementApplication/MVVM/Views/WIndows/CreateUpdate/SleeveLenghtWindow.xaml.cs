using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.CountryVM;
using ManagementApplication.MVVM.ViewModels.Actions.SleeveLenghtVM;
using ManagementApplication.MVVM.ViewModels.Actions.SleeveLenghtWindow;
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
    /// Логика взаимодействия для SleeveLenghtWindow.xaml
    /// </summary>
    public partial class SleeveLenghtWindow
    {
        public SleeveLenghtWindow(ActionBaseVM<SleeveLenght> actionBaseVM)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (actionBaseVM is CreateSleeveLenghtViewModel)
            {
                this.DataContext = actionBaseVM as CreateSleeveLenghtViewModel;
            }
            else if (actionBaseVM is UpdateSleeveLenghtViewModel)
            {
                this.DataContext = actionBaseVM as UpdateSleeveLenghtViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(actionBaseVM));
            }
        }
    }
}
