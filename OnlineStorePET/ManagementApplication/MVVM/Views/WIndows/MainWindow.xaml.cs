﻿using ManagementApplication.Models;
using ManagementApplication.MVVM.ViewModels;
using ManagementApplication.StaticFiles;
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

namespace ManagementApplication.MVVM.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            ResourseDictionarySetter.SetDictionaries(this);

            InitializeComponent();

            this.DataContext = mainWindowViewModel;
        }
    }
}