using ManagementApplication.MVVM.Core;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ManagementApplication.MVVM.ViewModels.Actions.FitVM
{
    public class UpdateFitViewModel : ActionBaseVM<Fit>
    {
        public UpdateFitViewModel() : base("Update", "fit")
        {
            
        }
        protected override RelayCommand actionCommand {get;set;} 
        public override RelayCommand ActionCommand 
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {

            });
        }
    }
}
