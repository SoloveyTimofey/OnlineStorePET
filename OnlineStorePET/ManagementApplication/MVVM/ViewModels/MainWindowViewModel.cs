using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ManagementApplication.MVVM.Views.Pages;
using System.Security.Cryptography;
using System.Net.Http;
using ManagementApplication.Models;
using System.Windows;
using ManagementApplication.Services.AbstractFactory___Facade;
using ManagementApplication.Services.Repositories.Interfaces;

namespace ManagementApplication.MVVM.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly IJwtStorageManager jwtStorageManager;
        private readonly IPageFactoryFacade factoryFacade;
        private readonly AuthenticationPageViewModel authenticationPageViewModel;
        private readonly MainPageViewModel mainPageViewModel;

        #pragma warning disable CS8618
        public MainWindowViewModel(IJwtStorageManager jwtStorageManager,IPageFactoryFacade factoryFacade,
            AuthenticationPageViewModel authenticationPageViewModel, MainPageViewModel mainPageViewModel)
        {
            this.jwtStorageManager = jwtStorageManager;
            this.factoryFacade = factoryFacade;
            this.authenticationPageViewModel = authenticationPageViewModel;
            this.mainPageViewModel = mainPageViewModel;

            authenticationPageViewModel.ActionOnPageSuccessful += AuthenticationSuccsessfulHandler;

            if (this.jwtStorageManager.CheckIfTokenExpired())
            {
                Page = factoryFacade.GetRequiredPage<AuthenticationPage>(authenticationPageViewModel);
            }
            else
            {
                AuthenticationSuccsessfulHandler();
            }
        }
        #pragma warning restore CS8618

        private Page page { get; set; }
        public Page Page
        {
            get => page;
            set
            {
                page = value;
                OnPropertyChanged();
            }
        }

        public void AuthenticationSuccsessfulHandler()
        {
            Page = factoryFacade.GetRequiredPage<MainPage>(mainPageViewModel);
        }
    }
}
