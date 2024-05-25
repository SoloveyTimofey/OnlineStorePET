using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Proxy;
using StoreDataModels;
using StoreDataModels.DTO;
using StoreDataModels.DTO.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.CountryVM
{
    public class CreateCountryViewModel : ActionBaseVM<Country>
    {
        private readonly GeneralRepositoryProxy generalRepositoryProxy;
        public CreateCountryViewModel(GeneralRepositoryProxy generalRepositoryProxy):base("Create", "country")
        {
            this.generalRepositoryProxy = generalRepositoryProxy;
            base.TargetModel = new Country();
        }

        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand 
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (String.IsNullOrEmpty(TargetModel.Name))
                {
                    ErrorMessage = "Name cannot be empty.";
                    return;
                }

                var result = await generalRepositoryProxy.CreateCountryAsync(DTOMapper.MapToDTO<Country, CountryDTO>(TargetModel));

                if (result.Item2==HttpStatusCode.OK)
                {
                    base.IsActionSuccessful = true;
                    TargetModel = new Country();
                }
            });
        }
    }
}
