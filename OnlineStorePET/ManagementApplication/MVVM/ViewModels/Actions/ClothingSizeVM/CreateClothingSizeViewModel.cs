using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Interfaces;
using ManagementApplication.Services.Repositories.Proxy;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using StoreDataModels;
using StoreDataModels.Clothes;
using StoreDataModels.DTO.Infrastructure;
using StoreDataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.ClothingSizeVM
{
    public class CreateClothingSizeViewModel : ActionBaseVM<ClothingSize>
    {
        private readonly ClothingRepositoryProxy clothingRepositoryProxy;
        public CreateClothingSizeViewModel(ClothingRepositoryProxy clothingRepositoryProxy) : base("Create", "clothing size")
        {
            this.clothingRepositoryProxy = clothingRepositoryProxy;
            base.TargetModel = new ClothingSize();
        }
        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (String.IsNullOrEmpty(TargetModel.Size))
                {
                    ErrorMessage = "Size name cannot be empty.";
                    return;
                }
                if (TargetModel.Size.Length>4)
                {
                    ErrorMessage = "Size name must be shorter.";
                    return;
                }

                var result = await clothingRepositoryProxy.CreateClothingSizeAsync(DTOMapper.MapToDTO<ClothingSize, ClothingSizeDTO>(TargetModel));

                if (result.Item2 == HttpStatusCode.OK)
                {
                    IsActionSuccessful = true;
                    TargetModel = new ClothingSize();
                }
            });
        }
    }
}
