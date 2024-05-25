using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StoreDataModels;
using System.Threading.Tasks;
using ManagementApplication.MVVM.Core;

namespace ManagementApplication.MVVM.ViewModels.Actions.CountryVM
{
    public class UpdateCountryViewModel : ActionBaseVM<Country>
    {
        public UpdateCountryViewModel() : base("Update", "Country")
        {
            
        }

        private Country targetModelPrototype { get; set; }
        public Country TargetModelPrototype
        {
            get => targetModelPrototype ?? throw new ArgumentNullException(nameof(targetModelPrototype));
            set
            {
                targetModelPrototype = value;
                OnPropertyChanged();
            }
        }

        protected override RelayCommand actionCommand { get; set;}
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(obj =>
            {

            });
        }

    }
}
