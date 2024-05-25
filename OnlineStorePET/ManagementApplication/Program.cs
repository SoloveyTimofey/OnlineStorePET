using ManagementApplication.MVVM.ViewModels;
using SimpleInjector;
using ManagementApplication.MVVM.Views.Windows;
using System.Net.Http;
using ManagementApplication.Services.Repositories.Proxy;
using System.Configuration;
using System.Windows;
using ManagementApplication.Services.Implementations.Repositories;
using ManagementApplication.Services.AbstractFactory;
using ManagementApplication.Services.AbstractFactory___Facade;
using ManagementApplication.MVVM.ViewModels.Actions.CountryVM;
using ManagementApplication.Services.Repositories.Interfaces;
using ManagementApplication.Services.Repositories.Repositories;
using ManagementApplication.Services.AbstractFactory___Facade.Windows;
using ManagementApplication.MVVM.ViewModels.Actions.BrandVM;
using ManagementApplication.MVVM.ViewModels.Actions.ColorVM;
using ManagementApplication.MVVM.ViewModels.Actions.SleeveLenghtWindow;
using ManagementApplication.MVVM.ViewModels.Actions.SleeveLenghtVM;
using ManagementApplication.MVVM.ViewModels.Actions.FitVM;
using ManagementApplication.MVVM.ViewModels.Actions.ClothingSizeVM;
using ManagementApplication.MVVM.ViewModels.Actions.CategoryVM;
using ManagementApplication.MVVM.ViewModels.Actions.CLothingVM;

namespace ManagementApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = CompositionRoot();

            RunApplication(container);
        }

        private static Container CompositionRoot()
        {
            var container = new Container();

            container.Register<IJwtStorageManager, JwtStorageManager>();
            container.Register<IAuthenticationRepository, AuthenticationRepository>();

            container.Register<AuthenticationPageFactory>(Lifestyle.Singleton);
            container.Register<ClothesPageFactory>(Lifestyle.Singleton);
            container.Register<CreatePageFactory>(Lifestyle.Singleton);
            container.Register<MainPageFactory>(Lifestyle.Singleton);
            container.Register<ShoesPageFactory>(Lifestyle.Singleton);
            container.Register<IPageFactoryFacade, PageFactoryFacade>(Lifestyle.Singleton);

            container.Register<CountryWindowFactory>(Lifestyle.Singleton);
            container.Register<BrandWindowFactory>(Lifestyle.Singleton);
            container.Register<ColorWindowFactory>(Lifestyle.Singleton);
            container.Register<SleeveLenghtWindowFactory>(Lifestyle.Singleton);
            container.Register<FitWindowFactory>(Lifestyle.Singleton);
            container.Register<ClothingSizeWindowFactory>(Lifestyle.Singleton);
            container.Register<CategoryWindowFactory>(Lifestyle.Singleton);
            container.Register<ClothingWindowFactory>(Lifestyle.Singleton);
            container.Register<IWindowFactoryFacade, WindowFactoryFacade>(Lifestyle.Singleton);

            container.Register<IClothingGetRepository, ClothingRepository>(Lifestyle.Singleton);
            container.Register<IClothingActionRepository, ClothingRepository>(Lifestyle.Singleton);
            container.Register(() => new ClothingRepositoryProxy(container.GetInstance<IClothingGetRepository>(),container.GetInstance<IClothingActionRepository>(), Main), Lifestyle.Singleton);
            container.Register<IGeneralActionRepository, GeneralRepository>(Lifestyle.Singleton);
            container.Register<IGeneralGetRepository, GeneralRepository>(Lifestyle.Singleton);
            container.Register(() => new GeneralRepositoryProxy(container.GetInstance<IGeneralActionRepository>(),container.GetInstance<IGeneralGetRepository>(), Main), Lifestyle.Singleton);

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseUrl"]!);

            container.RegisterInstance(httpClient);

            container.Register<MainWindow>();
       
            RegisterViewModels(container);

            container.Verify();

            return container;
        }

        private static void RegisterViewModels(Container container)
        {
            container.Register<MainWindowViewModel>();
            container.Register<AuthenticationPageViewModel>();
            container.Register<MainPageViewModel>();
            container.Register<ClothesPageViewModel>();
            container.Register<CreatePageViewModel>();
            container.Register<ShoesPageViewModel>();

            container.Register<CreateCountryViewModel>();
            container.Register<UpdateCountryViewModel>();

            container.Register<CreateBrandViewModel>();
            container.Register<UpdateBrandViewModel>();

            container.Register<CreateColorViewModel>();
            container.Register<UpdateColorViewModel>();

            container.Register<CreateSleeveLenghtViewModel>();
            container.Register<UpdateSleeveLenghtViewModel>();

            container.Register<CreateFitViewModel>();
            container.Register<UpdateFitViewModel>();

            container.Register<CreateClothingSizeViewModel>();
            container.Register<UpdateClothingSizeViewModel>();

            container.Register<CreateCategoryViewModel>();
            container.Register<UpdateCategoryViewModel>();

            container.Register<CreateClothingViewModel>();
            container.Register<UpdateClothingViewModel>();
        }

        private static void RunApplication(Container container)
        {
            try
            {
                var app = new App();

                var resouseDict = new ResourceDictionary();
                resouseDict.Source = new Uri($@"Themes\Colors.xaml", UriKind.RelativeOrAbsolute);
                app.Resources.MergedDictionaries.Add(resouseDict);

                var mainWindow = container.GetInstance<MainWindow>();
                app.Run(mainWindow);
            }
            catch (Exception)
            {

            }
        }
    }
}