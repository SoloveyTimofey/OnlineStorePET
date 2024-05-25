using ManagementApplication.MVVM.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ManagementApplication.Services.AbstractFactory;
using ManagementApplication.Services.AbstractFactory___Facade;
using ManagementApplication.MVVM.Views.Pages;

namespace ManagementApplication.MVVM.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IPageFactoryFacade factoryFacade;
        private readonly CreatePageViewModel createPageViewModel;
        private readonly ClothesPageViewModel clothesPageViewModel;
        private readonly ShoesPageViewModel shoesPageViewModel;

        #pragma warning disable CS8618
        public MainPageViewModel(IPageFactoryFacade factoryFacade, CreatePageViewModel createPageViewModel, ClothesPageViewModel clothesPageViewModel, ShoesPageViewModel shoesPageViewModel)
        {
            this.factoryFacade = factoryFacade;
            this.createPageViewModel = createPageViewModel;
            this.clothesPageViewModel = clothesPageViewModel;
            this.shoesPageViewModel = shoesPageViewModel;
        }
        #pragma warning restore CS8618

        #region Properties
        private Page currentPage { get; set; }
        public Page CurrentPage
        {
            get => currentPage ?? factoryFacade.GetRequiredPage<CreatePage>(createPageViewModel);
            set
            {
                currentPage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        private RelayCommand switchToPage { get; set; }
        public RelayCommand SwitchToPage
        {
            get => switchToPage ?? new RelayCommand(obj =>
            {
                string pageName = obj as string ?? throw new ArgumentException(nameof(obj));
                switch (pageName)
                {
                    case "Create":
                        if (!(CurrentPage is CreatePage))
                        {
                            CurrentPage = factoryFacade.GetRequiredPage<CreatePage>(createPageViewModel);
                        }
                        break;
                    case "Clothes":
                        if (!(CurrentPage is ClothesPage))
                        {
                            CurrentPage = factoryFacade.GetRequiredPage<ClothesPage>(clothesPageViewModel);
                        }
                        break;
                    case "Shoes":
                        if (!(CurrentPage is ShoesPage))
                        {
                            CurrentPage = factoryFacade.GetRequiredPage<ShoesPage>(shoesPageViewModel);
                        }
                        break;
                    default:
                        throw new NotImplementedException(nameof(obj));
                }
            });
        }
        #endregion
    }
}
