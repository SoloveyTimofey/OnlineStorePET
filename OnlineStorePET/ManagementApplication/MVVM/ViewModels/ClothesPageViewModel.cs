using ManagementApplication.MVVM.Core;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ManagementApplication.Services.Repositories.Proxy;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels
{
    public class ClothesPageViewModel : ViewModelBase
    {
        private readonly ClothingRepositoryProxy clothingGetRepository;
        public ClothesPageViewModel(ClothingRepositoryProxy clothingGetRepository)
        {
            this.clothingGetRepository = clothingGetRepository;
        }

        private ObservableCollection<Clothing> clothes;
        public ObservableCollection<Clothing> Clothes
        {
            get => clothes;
            set
            {
                clothes = value;
                OnPropertyChanged();
            }
        }
    }
}
