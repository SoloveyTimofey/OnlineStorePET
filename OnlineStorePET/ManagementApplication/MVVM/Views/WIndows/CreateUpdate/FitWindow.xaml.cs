﻿using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.CountryVM;
using ManagementApplication.MVVM.ViewModels.Actions.FitVM;
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
    /// Логика взаимодействия для FitWindow.xaml
    /// </summary>
    public partial class FitWindow
    {
        public FitWindow(ActionBaseVM<Fit> actionBaseVM)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            if (actionBaseVM is CreateFitViewModel)
            {
                this.DataContext = actionBaseVM as CreateFitViewModel;
            }
            else if (actionBaseVM is UpdateFitViewModel)
            {
                this.DataContext = actionBaseVM as UpdateFitViewModel;
            }
            else
            {
                throw new ArgumentException(nameof(actionBaseVM));
            }
        }
    }
}
