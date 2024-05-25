using ManagementApplication.MVVM.Core;
using StoreDataModels.Clothes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public class ExtendedClothingSize : ClothingSize, INotifyPropertyChanged
    {
        public ExtendedClothingSize(long id,string size)
        {
            this.Size = size;
            this.Id = id;
        }
        private bool isIncluded { get; set; }
        public bool IsIncluded
        {
            get => isIncluded;
            set
            {
                isIncluded = value;
                OnPropertyChanged();
            }
        }

        private long count { get; set; }
        public long Count
        {
            get=> count;
            set
            {
                count = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
