using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementApplication.MVVM.Views.Pages;
using System.Windows.Controls;
using System.CodeDom;
using ManagementApplication.Services.AbstractFactory___Facade;
using ManagementApplication.MVVM.Core;

namespace ManagementApplication.Services.AbstractFactory
{
    public class PageFactoryFacade : IPageFactoryFacade
    {
        private readonly AuthenticationPageFactory authenticationPageFactory;
        private readonly ClothesPageFactory clothesPageFactory;
        private readonly CreatePageFactory createPageFactory;
        private readonly MainPageFactory mainPageFactory;
        private readonly ShoesPageFactory shoesPageFactory;
        public PageFactoryFacade(AuthenticationPageFactory authenticationPageFactory,ClothesPageFactory clothesPageFactory,
            CreatePageFactory createPageFactory, MainPageFactory mainPageFactory, ShoesPageFactory shoesPageFactory)
        {
            this.authenticationPageFactory = authenticationPageFactory;
            this.clothesPageFactory = clothesPageFactory;
            this.createPageFactory = createPageFactory;
            this.mainPageFactory = mainPageFactory;
            this.shoesPageFactory = shoesPageFactory;
        }

        public Page GetRequiredPage<T>(ViewModelBase viewModel) where T : Page
        {
            if (typeof(T)==typeof(AuthenticationPage))
            {
                return authenticationPageFactory.CreatePage(viewModel);
            }
            else if (typeof(T)==typeof(ClothesPage))
            {
                return clothesPageFactory.CreatePage(viewModel);
            }
            else if (typeof(T)==typeof(CreatePage))
            {
                return createPageFactory.CreatePage(viewModel);
            }
            else if(typeof(T)==typeof(MainPage))
            {
                return mainPageFactory.CreatePage(viewModel);
            }
            else if (typeof(T) == typeof(ShoesPage))
            {
                return shoesPageFactory.CreatePage(viewModel);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
