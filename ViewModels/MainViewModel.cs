using ATM.Helpers;
using ATM.Models;
using ATM.Services.Implementation;
using ATM.Views;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ATM.ViewModels
{
    public class MainViewModel : ViewModel, INotifyPropertyChanged
    {
        private string _logInCardValue;
        public string LogInCardValue
        {
            get { return _logInCardValue; }
            set
            {
                _logInCardValue = value;
                OnPropertyChanged(nameof(LogInCardValue));
            }
        }
        private string _pinValue;
        public string PinValue
        {
            get { return _pinValue; }
            set
            {
                _pinValue = value;
                OnPropertyChanged(nameof(PinValue));
            }
        }
        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
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
        private string _registerMessage;
        public string RegisterMessage
        {
            get { return _registerMessage; }
            set
            {
                _registerMessage = value;
                OnPropertyChanged(nameof(RegisterMessage));
            }
        }
        public ICommand RegisterCommand { get; set; }
        public ICommand SignInCommand { get; set; }
        public ICommand SwitchToSignInCommand { get; set; }
        public ICommand SwitchToRegisterCommand { get; set; }

        private UserService _userService;

        public MainViewModel()
        {
            _userService = new UserService();

            RegisterCommand = new RelayCommand(param => Register());
            SwitchToRegisterCommand = new RelayCommand(param => SwitchStackPanel(true));
            SwitchToSignInCommand = new RelayCommand(param => SwitchStackPanel(false));
            SignInCommand = new RelayCommand(param => SignIn());
            
        }

        private void SwitchStackPanel(bool register)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var registerPanel = mainWindow.FindName("RegisterSection") as StackPanel;
                var signInPanel = mainWindow.FindName("SignInSection") as StackPanel;
                if (registerPanel != null && signInPanel != null)
                {
                    // change to register
                    if (register)
                    {
                        signInPanel.Visibility = Visibility.Collapsed;
                        registerPanel.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        registerPanel.Visibility = Visibility.Collapsed;
                        signInPanel.Visibility= Visibility.Visible;
                    }
                }
            }
        }

        private bool CanRegister()
        {
            if (string.IsNullOrEmpty(NameValue) || string.IsNullOrEmpty(SurnameValue) || string.IsNullOrEmpty(CardValue))
            {
                RegisterMessage = "You must fill in all fields.";
                return false;
            }

            if (CardValue.Length != 16 || !CardValue.All(char.IsDigit))
            {
                RegisterMessage = "Card number must be 16 digits.";
                return false;
            }

            RegisterMessage = null;
            return true;
        }

        private void Register()
        {
            if (CanRegister())
            {
                User user = _userService.Register(NameValue, SurnameValue, CardValue);
                if (user != null)
                {
                    RegisterMessage = "Hello " + user.Name;
                    //var mainWindow = Application.Current.MainWindow as MainWindow;
                    //if (mainWindow != null)
                    //{
                    //    UserWindow userWindow = new UserWindow(user);
                    //    Application.Current.MainWindow = userWindow;
                    //    userWindow.Show();
                    //    mainWindow.Close();
                    //}
                    _navigationService.NavigateToUserViewModel(user);
                }
                else
                {
                    RegisterMessage = "Card number already exists.";
                }
            }
        }

        private void SignIn()
        {
            if (!string.IsNullOrEmpty(PinValue) && !string.IsNullOrEmpty(LogInCardValue))
            {
                PinValue = PinValue.Trim();
                LogInCardValue = LogInCardValue.Trim();
                if (PinValue.Length == 4)
                {
                    if (LogInCardValue.Length == 16)
                    {
                        try
                        {
                            int pin = int.Parse(PinValue);
                            long card = long.Parse(LogInCardValue);
                            User user = _userService.FindCardNumber(card.ToString());
                            if (user != null)
                            {
                                _userService.UpdateLogInAttemptsNumber(user, user.AttemptsNumber + 1);
                                if (!user.IsBlocked)
                                {
                                    if (user.AttemptsNumber + 1 > 3)
                                    {
                                        _userService.BlockUser(user);
                                        PinValue = "";
                                        Message = "Blocked user. Sorry :(";
                                    }
                                    else
                                    {
                                        if (_userService.SignIn(user, pin))
                                        {
                                            _userService.UpdateLogInAttemptsNumber(user, 0);
                                            Message = "Hello " + user.Name;
                                            if (!user.IsAdmin)
                                            {
                                                //var mainWindow = Application.Current.MainWindow as MainWindow;
                                                //if (mainWindow != null)
                                                //{
                                                //    UserWindow userWindow = new UserWindow(user);
                                                //    Application.Current.MainWindow = userWindow;
                                                //    userWindow.Show();
                                                //    mainWindow.Close();
                                                //}
                                                _navigationService.NavigateToUserViewModel(user);
                                            }
                                            else
                                            {
                                                //var mainWindow = Application.Current.MainWindow as MainWindow;
                                                //if (mainWindow != null)
                                                //{
                                                //    AdminWindow adminWindow = new AdminWindow(user);
                                                //    Application.Current.MainWindow = adminWindow;
                                                //    adminWindow.Show();
                                                //    mainWindow.Close();
                                                //}
                                                _navigationService.NavigateToAdminViewModel(user);
                                            }
                                        }
                                        else
                                        {
                                            PinValue = "";
                                            Message = "Not valid PIN.";
                                        }
                                    }
                                }
                                else
                                {
                                    Message = "Blocked user. Sorry :(";
                                }
                            }
                            else
                            {
                                PinValue = "";
                                LogInCardValue = "";
                                Message = "Credit card number not found. \nYou can try to register.";
                            }
                        }
                        catch (FormatException)
                        {
                            Message = "Error with PIN or credit\n card number format.";
                            PinValue = null;
                        }
                        catch (OverflowException)
                        {
                            Message = "Error with PIN or credit\n card number overflow.";
                            PinValue = null;
                        }
                    }
                    else
                    {
                        Message = "Your credit card number\n must be 16 numbers long.";
                        PinValue = null;
                    }
                }
                else
                {
                    Message = "Your PIN must be 4 numbers long.";
                    PinValue = null;
                }
                
            }
            else
            {
                Message = "Please enter your credit\ncard number and PIN.";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
