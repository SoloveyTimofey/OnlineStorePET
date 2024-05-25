using ManagementApplication.MVVM.Core;
using ManagementApplication.MVVM.ViewModels.Actions;
using ManagementApplication.MVVM.ViewModels.Actions.CLothingVM;
using ManagementApplication.MVVM.Views.Windows.CreateUpdate;
using ManagementApplication.MVVM.Views.WIndows.CreateUpdate;
using StoreDataModels;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ManagementApplication.Services.AbstractFactory___Facade.Windows
{
    public class WindowFactoryFacade : IWindowFactoryFacade
    {
        private readonly CountryWindowFactory countryWindowFactory;
        private readonly BrandWindowFactory brandWindowFactory;
        private readonly ColorWindowFactory colorWindowFactory;
        private readonly SleeveLenghtWindowFactory sleeveLenghtWindowFactory;
        private readonly FitWindowFactory fitWindowFactory;
        private readonly ClothingSizeWindowFactory clothingSizeWindowFactory;
        private readonly CategoryWindowFactory categoryWindowFactory;
        private readonly ClothingWindowFactory clothingWindowFactory;
        public WindowFactoryFacade(CountryWindowFactory countryWindowFactory, BrandWindowFactory brandWindowFactory, ColorWindowFactory colorWindowFactory,
            SleeveLenghtWindowFactory sleeveLenghtWindowFactory, FitWindowFactory fitWindowFactory, ClothingSizeWindowFactory clothingSizeWindowFactory,
            CategoryWindowFactory categoryWindowFactory, ClothingWindowFactory clothingWindowFactory)
        {
            this.countryWindowFactory = countryWindowFactory;
            this.brandWindowFactory = brandWindowFactory;
            this.colorWindowFactory = colorWindowFactory;
            this.sleeveLenghtWindowFactory = sleeveLenghtWindowFactory;
            this.fitWindowFactory = fitWindowFactory;
            this.clothingSizeWindowFactory = clothingSizeWindowFactory;
            this.categoryWindowFactory = categoryWindowFactory;
            this.clothingWindowFactory = clothingWindowFactory;
        }
        public Window GetRequiredWindow<T>(ViewModelBase viewModel) where T : Window
        {
            if (typeof(T)==typeof(CountryWindow))
            {
                return countryWindowFactory.CreateWindow(viewModel as ActionBaseVM<Country> ?? throw new ArgumentException(nameof(viewModel)));
            }
            else if (typeof(T)==typeof(BrandWindow))
            {
                return brandWindowFactory.CreateWindow(viewModel as ActionBaseVM<Brand> ?? throw new ArgumentException(nameof(viewModel)));
            }
            else if(typeof(T)==typeof(ColorWindow))
            {
                return colorWindowFactory.CreateWindow(viewModel as ActionBaseVM<Color> ?? throw new ArgumentException(nameof(viewModel)));
            }
            else if(typeof(T)==typeof(SleeveLenghtWindow))
            {
                return sleeveLenghtWindowFactory.CreateWindow(viewModel as ActionBaseVM<SleeveLenght> ?? throw new ArgumentException(nameof(viewModel)));
            } 
            else if(typeof(T)==typeof(FitWindow))
            {
                return fitWindowFactory.CreateWindow(viewModel as ActionBaseVM<Fit> ?? throw  new ArgumentException(nameof(viewModel)));
            }
            else if(typeof(T)==typeof(ClothingSizeWindow))
            {
                return clothingSizeWindowFactory.CreateWindow(viewModel as ActionBaseVM<ClothingSize> ?? throw new ArgumentException(nameof(viewModel)));
            }
            else if(typeof(T)==typeof(CategoryWindow))
            {
                return categoryWindowFactory.CreateWindow(viewModel as ActionBaseVM<ClothingCategory> ?? throw new ArgumentException(nameof(viewModel)));
            }
            else if(typeof(T)==typeof(ClothingWindow))
            {
                return clothingWindowFactory.CreateWindow(viewModel as ActionBaseVM<Clothing> ?? throw new ArgumentException(nameof(viewModel)));
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
