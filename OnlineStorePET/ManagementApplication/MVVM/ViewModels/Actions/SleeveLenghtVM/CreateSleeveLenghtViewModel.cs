using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Proxy;
using StoreDataModels;
using StoreDataModels.Clothes;
using StoreDataModels.DTO.Infrastructure;
using StoreDataModels.DTO;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.SleeveLenghtWindow
{
    public class CreateSleeveLenghtViewModel : ActionBaseVM<SleeveLenght>
    {
        private readonly ClothingRepositoryProxy clothingRepositoryProxy;
        public CreateSleeveLenghtViewModel(ClothingRepositoryProxy clothingRepositoryProxy) : base("Create", "sleeve lenght")
        {
            this.clothingRepositoryProxy = clothingRepositoryProxy;
            base.TargetModel = new SleeveLenght();
        }
        protected override RelayCommand actionCommand { get; set; }

        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (String.IsNullOrEmpty(TargetModel.Lenght))
                {
                    ErrorMessage = "Sleeve Lenght Name cannot be empty.";
                    return;
                }

                var result = await clothingRepositoryProxy.CreateSleeveLenghtAsync(DTOMapper.MapToDTO<SleeveLenght, SleeveLenghtDTO>(TargetModel));

                if (result.Item2 == HttpStatusCode.OK)
                {
                    base.IsActionSuccessful = true;
                    TargetModel = new SleeveLenght();
                }
            });
        }
    }
}
