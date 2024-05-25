using ManagementApplication.MVVM.Core;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions.ColorVM
{
    public class UpdateColorViewModel : ActionBaseVM<Color>
    {
        public UpdateColorViewModel() : base("Update", "color")
        {
        }

        public override RelayCommand ActionCommand => throw new NotImplementedException();

        protected override RelayCommand actionCommand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
