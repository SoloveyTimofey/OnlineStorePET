using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Proxy;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Security.AccessControl;
using System.Text;
using StoreDataModels.DTO.Infrastructure;
using System.Threading.Tasks;
using StoreDataModels.DTO;

namespace ManagementApplication.MVVM.ViewModels.Actions.BrandVM
{
    public class CreateBrandViewModel : ActionBaseVM<Brand>
    {
        private readonly GeneralRepositoryProxy generalRepositoryProxy;
        public CreateBrandViewModel(GeneralRepositoryProxy generalRepositoryProxy) : base("Create", "brand")
        {
            this.generalRepositoryProxy = generalRepositoryProxy;
            base.TargetModel = new Brand();
        }
        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (SelectedCountry == null)
                {
                    ErrorMessage = "Select the country.";
                    return;
                }
                else if(String.IsNullOrEmpty(TargetModel.Name))
                {
                    ErrorMessage = "Select country name.";
                    return;
                }

                TargetModel.CountryId = SelectedCountry.Id;
                var result = await generalRepositoryProxy.CreateBrandAsync(DTOMapper.MapToDTO<Brand, BrandDTO>(TargetModel));

                if (result.Item2==HttpStatusCode.OK)
                {
                    IsActionSuccessful = true;
                    TargetModel = new Brand();
                    SelectedCountry = null;
                }
            });
        }

        private IEnumerable<Country> countries { get; set; }
        public IEnumerable<Country> Countries
        {
            get => countries;
            set
            {
                countries = value;
                OnPropertyChanged();
            }

        }

        private RelayCommand brandWindowActivated { get; set; }
        public RelayCommand BrandWindowActivated
        {
            get => brandWindowActivated ?? new RelayCommand(async obj =>
            {
                var result = await generalRepositoryProxy.GetAllCountriesAsync();
                Countries = result.Item1;
            });
        }

        private Country selectedCountry { get; set; }
        public Country SelectedCountry
        {
            get => selectedCountry;
            set
            {
                selectedCountry = value;
                OnPropertyChanged();
            }
        }
    }
}
