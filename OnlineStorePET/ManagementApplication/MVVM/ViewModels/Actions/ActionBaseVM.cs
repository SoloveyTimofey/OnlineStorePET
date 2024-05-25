using ManagementApplication.MVVM.Core;
using StoreDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.MVVM.ViewModels.Actions
{
    public abstract class ActionBaseVM<T> : ViewModelBase where T : IPrototype<T>
    {
        public ActionBaseVM(string actionTitle, string targetTitle)
        {
            this.ActionTitle = actionTitle;
            this.TargetTitle = targetTitle;
        }
        public string ActionTitle { get; set; }
        public string TargetTitle { get; set; }

        public string errorMessage { get; set; }
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        private bool isActionSuccessful { get; set; } = false;
        public bool IsActionSuccessful
        {
            get => isActionSuccessful;
            set
            {
                isActionSuccessful = value;
                OnPropertyChanged();
            }
        }

        private T targetModel { get; set; }
        public T TargetModel
        {
            get => targetModel;
            set
            {
                targetModel = value;
                OnPropertyChanged();
            }
        }

        protected abstract RelayCommand actionCommand { get; set; }
        public abstract RelayCommand ActionCommand { get; }
    }
}
