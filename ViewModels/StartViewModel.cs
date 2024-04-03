using ATM.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ATM.ViewModels
{
    public class StartViewModel : INotifyPropertyChanged
    {
        private NavigationService navigation;

        public NavigationService Navigation
        {
            get => navigation;
            set
            {
                navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }

        public StartViewModel()
        {
            Navigation = new NavigationService();
            ViewModel.InitializeNavigationService(Navigation);
            Navigation.NavigateToMainViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
