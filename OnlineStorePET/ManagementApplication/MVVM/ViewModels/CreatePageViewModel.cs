using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels.Actions.BrandVM;
using ManagementApplication.MVVM.ViewModels.Actions.ColorVM;
using ManagementApplication.MVVM.ViewModels.Actions.CountryVM;
using ManagementApplication.MVVM.ViewModels.Actions.FitVM;
using ManagementApplication.MVVM.ViewModels.Actions.ClothingSizeVM;
using ManagementApplication.MVVM.ViewModels.Actions.SleeveLenghtWindow;
using ManagementApplication.MVVM.Views.Windows.CreateUpdate;
using ManagementApplication.MVVM.Views.WIndows.CreateUpdate;
using ManagementApplication.Services.AbstractFactory___Facade.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ManagementApplication.MVVM.ViewModels.Actions.CategoryVM;
using ManagementApplication.MVVM.ViewModels.Actions.CLothingVM;

namespace ManagementApplication.MVVM.ViewModels
{
    public class CreatePageViewModel : ViewModelBase
    {
        private readonly IWindowFactoryFacade windowFactoryFacade;
        private readonly CreateCountryViewModel createCountryViewModel;
        private readonly CreateBrandViewModel createBrandViewModel;
        private readonly CreateColorViewModel createColorViewModel;
        private readonly CreateSleeveLenghtViewModel createSleeveLenghtViewModel;
        private readonly CreateFitViewModel createFitViewModel;
        private readonly CreateClothingSizeViewModel createClothingSizeViewModel;
        private readonly CreateCategoryViewModel createCategoryViewModel;
        private readonly CreateClothingViewModel createClothingViewModel;
        public CreatePageViewModel(IWindowFactoryFacade windowFactoryFacade, 
            CreateCountryViewModel createCountryViewModel, CreateBrandViewModel createBrandViewModel,
            CreateColorViewModel createColorViewModel, CreateSleeveLenghtViewModel createSleeveLenghtViewModel,
            CreateFitViewModel createFitViewModel, CreateClothingSizeViewModel createClothingSizeViewModel,
            CreateCategoryViewModel createCategoryViewModel, CreateClothingViewModel createClothingViewModel)
        {
            this.windowFactoryFacade = windowFactoryFacade;
            this.createCountryViewModel = createCountryViewModel;
            this.createBrandViewModel = createBrandViewModel;
            this.createColorViewModel = createColorViewModel;
            this.createSleeveLenghtViewModel = createSleeveLenghtViewModel;
            this.createFitViewModel = createFitViewModel;
            this.createClothingSizeViewModel = createClothingSizeViewModel;
            this.createCategoryViewModel = createCategoryViewModel;
            this.createClothingViewModel = createClothingViewModel;
        }

        #region Commands
        private RelayCommand createModelCommand { get; set; }
        public RelayCommand CreateModelCommand
        {
            get => createModelCommand ?? new RelayCommand(obj =>
            {
                string pageName = obj as string ?? throw new ArgumentException(nameof(obj));

                Window windowToOpen;
                switch(pageName)
                {
                    case "Country":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<CountryWindow>(createCountryViewModel);
                        break;
                    case "Brand":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<BrandWindow>(createBrandViewModel);
                        break;
                    case "Color":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<ColorWindow>(createColorViewModel);
                        break;
                    case "Sleeve lenght":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<SleeveLenghtWindow>(createSleeveLenghtViewModel);
                        break;
                    case "Fit":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<FitWindow>(createFitViewModel);
                        break;
                    case "Clothing size":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<ClothingSizeWindow>(createClothingSizeViewModel);
                        break;
                    case "Clothing category":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<CategoryWindow>(createCategoryViewModel);
                        break;
                    case "Clothing":
                        windowToOpen = windowFactoryFacade.GetRequiredWindow<ClothingWindow>(createClothingViewModel);
                        break;
                    default:
                        throw new NotImplementedException(nameof(obj));
                }
                windowToOpen?.Show();
            });
        }
        #endregion
    }
}
