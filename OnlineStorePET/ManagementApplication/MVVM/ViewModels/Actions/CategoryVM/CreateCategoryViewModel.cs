using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Interfaces;
using ManagementApplication.Services.Repositories.Proxy;
using StoreDataModels;
using StoreDataModels.Clothes;
using StoreDataModels.DTO.Infrastructure;
using StoreDataModels.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.CategoryVM
{
    public class CreateCategoryViewModel : ActionBaseVM<ClothingCategory>
    {
        private readonly ClothingRepositoryProxy clothingRepositoryProxy;
        public CreateCategoryViewModel(ClothingRepositoryProxy clothingRepositoryProxy) : base("Create", "category")
        {
            this.clothingRepositoryProxy = clothingRepositoryProxy;

            TargetModel = new ClothingCategory();
        }

        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (String.IsNullOrEmpty(TargetModel.Name))
                {
                    ErrorMessage = "Category Name cannot be empty.";
                    return;
                }

                var result = await clothingRepositoryProxy.CreateClothingCategoryAsync(DTOMapper.MapToDTO<ClothingCategory, ClothingCategoryDTO>(TargetModel));

                if (result.Item2 == HttpStatusCode.OK)
                {
                    IsActionSuccessful = true;
                    TargetModel = new ClothingCategory();
                }
            });
        }
    }
}
