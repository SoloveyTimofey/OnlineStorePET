using ManagementApplication.MVVM.Core;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.SleeveLenghtVM
{
    public class UpdateSleeveLenghtViewModel : ActionBaseVM<SleeveLenght>
    {
        public UpdateSleeveLenghtViewModel() : base("Update", "sleeve lenght")
        {
            
        }

        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand => throw new NotImplementedException();
    }
}
