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
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;

namespace ATM.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged
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

        private string _ballance;
        public string Ballance
        {
            get { return _ballance; }
            set
            {
                _ballance = value;
                OnPropertyChanged(nameof(Ballance));
            }
        }

        private int _wAmount;
        private string _withdrawAmount;
        public string WithdrawAmount
        {
            get { return _withdrawAmount; }
            set
            {
                _withdrawAmount = value;
                OnPropertyChanged(nameof(WithdrawAmount));
            }
        }

        private int _tAmount;
        private string _topupAmount;
        public string TopUpAmount
        {
            get { return _topupAmount; }
            set
            {
                _topupAmount = value;
                OnPropertyChanged(nameof(TopUpAmount));
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

        public ICommand WithdrawCommand { get; set; }
        public ICommand TopUpCommand { get; set; }
        public ICommand BallanceCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand EditProfileCommand { get; set; }
        public ICommand GenerateReportCommand { get; set; }
        public ICommand WithdrawCancelCommand { get; set; }
        public ICommand WithdrawDoneCommand { get; set; }
        public ICommand TopUpDoneCommand { get; set; }
        public ICommand TopUpCancelCommand { get; set; }
        public ICommand EditCancelCommand { get; set; }
        public ICommand EditDoneCommand { get; set; }

        private UserService _userService;

        public UserViewModel(User user)
        {
            _userService = new UserService();

            WithdrawCommand = new RelayCommand(param => Withdraw());
            TopUpCommand = new RelayCommand(param => TopUp());
            BallanceCommand = new RelayCommand(param => ShowBallance());
            EditProfileCommand = new RelayCommand(param => EditProfile());
            LogOutCommand = new RelayCommand(param => LogOut());
            GenerateReportCommand = new RelayCommand(param => GenerateReport());
            WithdrawCancelCommand = new RelayCommand(param => CancelWithdraw());
            WithdrawDoneCommand = new RelayCommand(param => DoneWithdraw());
            TopUpCancelCommand = new RelayCommand(param => CancelTopUp());
            TopUpDoneCommand = new RelayCommand(param => DoneTopUp());
            EditCancelCommand = new RelayCommand(param => CancelEdit());
            EditDoneCommand = new RelayCommand(param => DoneEdit());
            _user = user;
            _ballance = user.Ballance.ToString();
            _wAmount = 0;
            _withdrawAmount = _wAmount.ToString();
            _tAmount = 0;
            _topupAmount = _tAmount.ToString();
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

        private void GenerateReport()
        {
            if (_userService.GenerateReport(User))
            {
                MessageBox.Show("Successfully generated.");
            }
            else
            {
                MessageBox.Show("Error creating report.");
            }
        }

        private void EditProfile()
        {
            var mainWindow = Application.Current.MainWindow as UserWindow;
            if (mainWindow != null)
            {
                var ballancePanel = mainWindow.FindName("BallanceSection") as StackPanel;
                var withdrawPanel = mainWindow.FindName("WithdrawSection") as StackPanel;
                var topUpPanel = mainWindow.FindName("TopUpSection") as StackPanel;
                var editPanel = mainWindow.FindName("EditProfileSection") as StackPanel;
                if (ballancePanel != null && withdrawPanel != null && topUpPanel != null && editPanel != null)
                {
                    withdrawPanel.Visibility = Visibility.Collapsed;
                    topUpPanel.Visibility = Visibility.Collapsed;
                    ballancePanel.Visibility = Visibility.Collapsed;
                    editPanel.Visibility = Visibility.Visible;
                }
            }
        }

        private void LogOut()
        {
            var userWindow = Application.Current.MainWindow as UserWindow;
            if (userWindow != null)
            {
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                userWindow.Close();
            }
        }

        private void ShowBallance()
        {
            var mainWindow = Application.Current.MainWindow as UserWindow;
            if (mainWindow != null)
            {
                var ballancePanel = mainWindow.FindName("BallanceSection") as StackPanel;
                var withdrawPanel = mainWindow.FindName("WithdrawSection") as StackPanel;
                var topUpPanel = mainWindow.FindName("TopUpSection") as StackPanel;
                var editPanel = mainWindow.FindName("EditProfileSection") as StackPanel;
                if (ballancePanel != null && withdrawPanel != null && topUpPanel != null && editPanel != null)
                {
                        withdrawPanel.Visibility = Visibility.Collapsed;
                        topUpPanel.Visibility = Visibility.Collapsed;
                        editPanel.Visibility = Visibility.Collapsed;
                        ballancePanel.Visibility = Visibility.Visible;
                }
            }
        }

        private void Withdraw()
        {
            var mainWindow = Application.Current.MainWindow as UserWindow;
            if (mainWindow != null)
            {
                var ballancePanel = mainWindow.FindName("BallanceSection") as StackPanel;
                var withdrawPanel = mainWindow.FindName("WithdrawSection") as StackPanel;
                var topUpPanel = mainWindow.FindName("TopUpSection") as StackPanel;
                var editPanel = mainWindow.FindName("EditProfileSection") as StackPanel;
                if (ballancePanel != null && withdrawPanel != null && topUpPanel != null && editPanel != null)
                {
                    topUpPanel.Visibility = Visibility.Collapsed;
                    editPanel.Visibility = Visibility.Collapsed;
                    ballancePanel.Visibility = Visibility.Collapsed;
                    withdrawPanel.Visibility = Visibility.Visible;
                }
            }
        }
        private void DoneWithdraw()
        {
            if (CanWithdraw())
            {
                _userService.Withdraw(User, double.Parse(WithdrawAmount));
                MessageBox.Show("Successful transaction.");
                _wAmount = 0;
                WithdrawAmount = _wAmount.ToString();
                Ballance = User.Ballance.ToString();
            }
            else
            {
                MessageBox.Show("Bad input.");
                _wAmount = 0;
                WithdrawAmount = _wAmount.ToString();
            }
        }

        private bool CanWithdraw()
        {
            if (double.TryParse(WithdrawAmount, out double amount))
            {
                if (amount > User.Ballance || amount < 0 || amount > 1000)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void CancelWithdraw()
        {
            _wAmount = 0;
            WithdrawAmount = _wAmount.ToString();
        }

        private void TopUp()
        {
            var mainWindow = Application.Current.MainWindow as UserWindow;
            if (mainWindow != null)
            {
                var ballancePanel = mainWindow.FindName("BallanceSection") as StackPanel;
                var withdrawPanel = mainWindow.FindName("WithdrawSection") as StackPanel;
                var topUpPanel = mainWindow.FindName("TopUpSection") as StackPanel;
                var editPanel = mainWindow.FindName("EditProfileSection") as StackPanel;
                if (ballancePanel != null && withdrawPanel != null && topUpPanel != null && editPanel != null)
                {
                    withdrawPanel.Visibility = Visibility.Collapsed;
                    editPanel.Visibility = Visibility.Collapsed;
                    ballancePanel.Visibility = Visibility.Collapsed;
                    topUpPanel.Visibility = Visibility.Visible;
                }
            }
        }

        private void DoneTopUp()
        {
            if (CanTopUp())
            {
                _userService.TopUp(User, double.Parse(TopUpAmount));
                MessageBox.Show("Successful transaction.");
                _tAmount = 0;
                TopUpAmount = _tAmount.ToString();
                Ballance = User.Ballance.ToString();
            }
            else
            {
                MessageBox.Show("Bad input.");
                _tAmount = 0;
                TopUpAmount = _tAmount.ToString();
            }
        }

        private bool CanTopUp()
        {
            if (double.TryParse(TopUpAmount, out double amount))
            {
                if (amount < 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
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

        private void CancelTopUp()
        {
            _tAmount = 0;
            TopUpAmount = _tAmount.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
