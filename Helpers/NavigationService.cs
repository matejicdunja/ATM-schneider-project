using ATM.Models;
using ATM.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ATM.Helpers
{
    public class NavigationService : INotifyPropertyChanged
    {
        private UserControl _currentView;

        public UserControl CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }
        private ViewModel _currentViewModel;

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            private set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public void NavigateToMainViewModel()
        {
            CurrentView = new MainView();
        }

        public void NavigateToUserViewModel(User user)
        {
            CurrentView = new UserView(user);
        }

        public void NavigateToAdminViewModel(User user)
        {
            CurrentView = new AdminView(user);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
