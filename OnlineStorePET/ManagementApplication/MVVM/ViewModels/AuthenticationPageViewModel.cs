using ManagementApplication.Models;
using ManagementApplication.MVVM.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StoreDataModels.Identity;
using System.Net;
using ManagementApplication.Services.Repositories.Interfaces;

namespace ManagementApplication.MVVM.ViewModels
{
    public class AuthenticationPageViewModel : ViewModelBase
    {
        private readonly IAuthenticationRepository authenticationRepository;
        public event ActionOnPageSuccsessful ActionOnPageSuccessful;
    
        #pragma warning disable CS8618
        public AuthenticationPageViewModel(IAuthenticationRepository authenticationRepository)
        {
            this.authenticationRepository = authenticationRepository;
        }
        #pragma warning restore CS8618

        private RelayCommand signIn { get; set; }

        public RelayCommand SignIn
        {
            get => signIn ?? new RelayCommand(async obj =>
            {
                if (String.IsNullOrEmpty(UserName))
                {
                    WarningMessage = "Name cannot be empty.";
                    return;
                }
                if (String.IsNullOrEmpty(Password))
                {
                    WarningMessage = "Password cannot be empty.";
                    return;
                }

                JwtResponse response = await authenticationRepository.SignInAsync(new SignInCredentials
                {
                    Password = Password,
                    Username = UserName
                });

                if (response.Success == false)
                {
                    WarningMessage = "Invalid UserName or Password.";
                    return;
                }
                ActionOnPageSuccessful();
            });
        }

        private string userName { get; set; }
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged();
            }
        }

        private string password { get; set; }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private string warningMessage { get; set; }
        public string WarningMessage
        {
            get=> warningMessage;
            set
            {
                warningMessage = value;
                OnPropertyChanged();
            }
        }
    }
}
