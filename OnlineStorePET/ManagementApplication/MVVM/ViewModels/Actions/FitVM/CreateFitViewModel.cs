using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using StoreDataModels.DTO.Infrastructure;
using StoreDataModels.DTO;
using StoreDataModels;
using System.Net;

namespace ManagementApplication.MVVM.ViewModels.Actions.FitVM
{
    public class CreateFitViewModel : ActionBaseVM<Fit>
    {
        private readonly IClothingActionRepository clothingActionRepository;
        public CreateFitViewModel(IClothingActionRepository clothingActionRepository) : base("Create", "fit")
        {
            this.clothingActionRepository = clothingActionRepository;
            base.TargetModel = new Fit();
        }
        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (String.IsNullOrEmpty(TargetModel.Name))
                {
                    ErrorMessage = "Name cannot be null";
                    return;
                }

                var result = await clothingActionRepository.CreateFitAsync(DTOMapper.MapToDTO<Fit, FitDTO>(TargetModel));

                if (result.Item2 == HttpStatusCode.OK)
                {
                    base.IsActionSuccessful = true;
                    TargetModel = new Fit();
                }
            });
        }

    }
}
