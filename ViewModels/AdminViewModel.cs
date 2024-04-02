using ATM.Helpers;
using ATM.Models;
using ATM.Services.Implementation;
using ATM.Views;
using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using System.Collections.ObjectModel;
using ATM.Services.Interfaces;
using System.Windows.Controls;

namespace ATM.ViewModels
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }
        private string _date;
        private DispatcherTimer _timer;
        public string Datum
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Datum));
            }
        }
        private ObservableCollection<User> _blockedUsers;
        public ObservableCollection<User> BlockedUsers
        {
            get { return _blockedUsers; }
            set
            {
                _blockedUsers = value;
                OnPropertyChanged(nameof(BlockedUsers));
            }
        }
        private User _selectedUser;
        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                    OnPropertyChanged(nameof(SelectedUser));
                }
            }
        }
        private string _nameValue;
        public string NameValue
        {
            get { return _nameValue; }
            set
            {
                _nameValue = value;
                OnPropertyChanged(nameof(NameValue));
            }
        }

        private string _surnameValue;
        public string SurnameValue
        {
            get { return _surnameValue; }
            set
            {
                _surnameValue = value;
                OnPropertyChanged(nameof(SurnameValue));
            }
        }

        private string _cardValue;
        public string CardValue
        {
            get { return _cardValue; }
            set
            {
                _cardValue = value;
                OnPropertyChanged(nameof(CardValue));
            }
        }
        public ICommand LogOutCommand { get; set; }
        public ICommand EditProfileCommand { get; set; }
        public ICommand UnblockUserCommand { get; set; }
        public ICommand EditCancelCommand { get; set; }
        public ICommand EditDoneCommand { get; set; }
        public ICommand BackCommand { get; set; }

        private UserService _userService;

        public AdminViewModel(User user)
        {
            _userService = new UserService();

            EditProfileCommand = new RelayCommand(param => EditProfile());
            EditCancelCommand = new RelayCommand(param => CancelEdit());
            EditDoneCommand = new RelayCommand(param => DoneEdit());
            BackCommand = new RelayCommand(param => Back());
            UnblockUserCommand = new RelayCommand(param => UnblockUser());
            LogOutCommand = new RelayCommand(param => LogOut());
            _user = user;
            BlockedUsers = new ObservableCollection<User>(_userService.GetBlockedUsers());
            _nameValue = User.Name;
            _surnameValue = User.LastName;
            _cardValue = User.CreditCardNumber;

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Datum = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
        }

        private void LogOut()
        {
            var adminWindow = Application.Current.MainWindow as AdminWindow;
            if (adminWindow != null)
            {
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                adminWindow.Close();
            }
        }

        private bool CanUnblockUser()
        {
            return SelectedUser != null && SelectedUser.IsBlocked;
        }

        private void UnblockUser()
        {
            if (CanUnblockUser())
            {
                _userService.UnblockUser(SelectedUser);
                BlockedUsers = new ObservableCollection<User>(_userService.GetBlockedUsers());
            }
        }

        private void EditProfile()
        {
            var mainWindow = Application.Current.MainWindow as AdminWindow;
            if (mainWindow != null)
            {
                var blockedPanel = mainWindow.FindName("BlockedUsersSection") as StackPanel;
                var editPanel = mainWindow.FindName("EditProfileSection") as StackPanel;
                if (blockedPanel != null && editPanel != null)
                {
                    blockedPanel.Visibility = Visibility.Collapsed;
                    editPanel.Visibility = Visibility.Visible;
                }
            }
        }

        private void Back()
        {
            var mainWindow = Application.Current.MainWindow as AdminWindow;
            if (mainWindow != null)
            {
                var blockedPanel = mainWindow.FindName("BlockedUsersSection") as StackPanel;
                var editPanel = mainWindow.FindName("EditProfileSection") as StackPanel;
                if (blockedPanel != null && editPanel != null)
                {
                    blockedPanel.Visibility = Visibility.Visible;
                    editPanel.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void CancelEdit()
        {
            NameValue = User.Name;
            SurnameValue = User.LastName;
            CardValue = User.CreditCardNumber;
        }

        private bool CanEdit()
        {
            if (string.IsNullOrEmpty(NameValue) || string.IsNullOrEmpty(SurnameValue) || string.IsNullOrEmpty(CardValue))
            {
                return false;
            }

            if (CardValue.Length != 16 || !CardValue.All(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        private void DoneEdit()
        {
            if (CanEdit())
            {
                _userService.EditProfile(User, NameValue, SurnameValue, CardValue);
            }
            else
            {
                MessageBox.Show("Error with input");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
