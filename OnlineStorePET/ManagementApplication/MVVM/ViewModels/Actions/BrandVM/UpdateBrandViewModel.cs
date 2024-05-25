using ManagementApplication.MVVM.Core;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.BrandVM
{
    public class UpdateBrandViewModel : ActionBaseVM<Brand>
    {
        public UpdateBrandViewModel() : base("Update", "Brand")
        {
            
        }

        public override RelayCommand ActionCommand => throw new NotImplementedException();

        protected override RelayCommand actionCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
