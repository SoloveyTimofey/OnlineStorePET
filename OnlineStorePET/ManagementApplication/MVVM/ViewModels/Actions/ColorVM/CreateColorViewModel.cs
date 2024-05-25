using ManagementApplication.MVVM.Core;
using ManagementApplication.Services.Repositories.Proxy;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using StoreDataModels.DTO.Infrastructure;
using StoreDataModels.DTO;
using System.Threading.Tasks;
using System.Net;

namespace ManagementApplication.MVVM.ViewModels.Actions.ColorVM
{
    public class CreateColorViewModel : ActionBaseVM<Color>
    {
        private readonly GeneralRepositoryProxy generalRepositoryProxy;
        public CreateColorViewModel(GeneralRepositoryProxy generalRepositoryProxy) : base("Create", "color")
        {
            this.generalRepositoryProxy = generalRepositoryProxy;
            base.TargetModel = new Color();
        }

        protected override RelayCommand actionCommand { get; set; }
        public override RelayCommand ActionCommand
        {
            get => actionCommand ?? new RelayCommand(async obj =>
            {
                if (String.IsNullOrEmpty(TargetModel.Name))
                {
                    ErrorMessage = "Color Name cannot be empty.";
                    return;
                }
                else if(String.IsNullOrEmpty(_HEX))
                {
                    ErrorMessage = "Select the color.";
                    return;
                }

                HEX = _HEX.Remove(1, 2);
                TargetModel.HEX = HEX;

                var result = await generalRepositoryProxy.CreateColorAsync(DTOMapper.MapToDTO<Color, ColorDTO>(TargetModel));

                if (result.Item2==HttpStatusCode.OK)
                {
                    base.IsActionSuccessful = true;
                    TargetModel = new Color();
                }
            });
        }

        private string _HEX { get; set; }
        public string HEX
        {
            get => _HEX;
            set
            {
                _HEX = value;
                OnPropertyChanged();
            }
        }
    }
}
