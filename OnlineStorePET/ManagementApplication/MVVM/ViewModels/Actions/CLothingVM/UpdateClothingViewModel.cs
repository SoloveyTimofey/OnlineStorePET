using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Proxy;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.CLothingVM
{
    public class UpdateClothingViewModel : ActionBaseVM<Clothing>
    {
        private readonly ClothingRepositoryProxy clothingRepositoryProxy;
        public UpdateClothingViewModel(ClothingRepositoryProxy clothingRepositoryProxy):base("Update", "clothing")
        {
            this.clothingRepositoryProxy = clothingRepositoryProxy;
        }

        protected override RelayCommand actionCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override RelayCommand ActionCommand => throw new NotImplementedException();
    }
}
