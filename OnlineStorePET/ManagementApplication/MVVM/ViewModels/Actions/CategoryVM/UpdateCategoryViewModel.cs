using ManagementApplication.MVVM.Core;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.CategoryVM
{
    public class UpdateCategoryViewModel : ActionBaseVM<ClothingCategory>
    {
        public UpdateCategoryViewModel() : base("Update", "category")
        {
            
        }

        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {

            });
        }
    }
}
