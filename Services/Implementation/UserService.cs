using ATM.Models;
using ATM.Repository;
using ATM.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Xml.Linq;

namespace ATM.Services.Implementation
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        private TransactionRepository _transactionRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
            _transactionRepository = new TransactionRepository();
        }

        public bool GenerateReport(User user)
        {
            try
            {
                string filePath = $"../../Resources/Data/Report_{user.Name}_{user.LastName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(" ");
                    writer.WriteLine("ATM REPORT");
                    writer.WriteLine(" ");
                    writer.WriteLine("************************************************ ");
                    writer.WriteLine(" ");
                    writer.WriteLine($"Name: {user.Name} {user.LastName}");
                    writer.WriteLine($"Credit card number: {user.CreditCardNumber}");
                    writer.WriteLine($"Date and Time: {DateTime.Now}");
                    writer.WriteLine($"Balance: {user.Ballance}");
                    writer.WriteLine(" ");
                    writer.WriteLine("************************************************ ");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public long GenerateId()
        {
            var allIds = _userRepository.GetAllIds();
            Random random = new Random();
            long newId;
            do
            {
                newId = random.Next(1, 999999);
            } while (allIds.Contains(newId));

            return newId;
        }

        public int GeneratePin()
        {
            var allPins = _userRepository.GetAllPins();
            Random random = new Random();
            int newPin;
            do
            {
                newPin = random.Next(1000, 9999);
            } while (allPins.Contains(newPin));

            return newPin;
        }

        public User Register(string name, string lastName, string creditCardNumber)
        {
            if (!_userRepository.CheckForCardNumber(creditCardNumber))
            {
                User user = new User(GenerateId(), name, lastName, GeneratePin(), false, 
                    creditCardNumber, 0,  false, 0.0);
                _userRepository.Add(user);
                return user;
            }
            return null;
        }

        public User FindCardNumber(string card)
        {
            return _userRepository.GetUserByCard(card);
        }

        public bool SignIn(User user, int pin)
        {
            return user.Pin == pin;
        }

        public long GenerateTransactionId()
        {
            var allIds = _transactionRepository.GetAllIds();
            Random random = new Random();
            long newId;
            do
            {
                newId = random.Next(1, 999999);
            } while (allIds.Contains(newId));

            return newId;
        }

        public void TopUp(User user, double amount)
        {
            user.Ballance += amount;
            _userRepository.SaveChanges(user);
            _transactionRepository.Save(new Transaction(GenerateTransactionId(), user.Id, DateTime.Now, amount));
        }

        public void Withdraw(User user, double amount)
        {
            user.Ballance -= amount;
            _userRepository.SaveChanges(user);
            _transactionRepository.Save(new Transaction(GenerateTransactionId(), user.Id, DateTime.Now, -amount));
        }

        public void EditProfile(User user, string name, string surname, string card)
        {
            user.Name = name;
            user.LastName = surname;
            user.CreditCardNumber = card;
            _userRepository.SaveChanges(user);
        }

        public void UpdateLogInAttemptsNumber(User user, int attempts)
        {
            _userRepository.SaveLogInAttempts(user, attempts);
        }

        public List<User> GetBlockedUsers()
        {
            return _userRepository.LoadAllBlocked();
        }

        public void BlockUser(User user)
        {
            user.IsBlocked = true;
            _userRepository.SaveChanges(user);
        }

        public void UnblockUser(User user)
        {
            user.IsBlocked = false;
            _userRepository.SaveChanges(user);
            UpdateLogInAttemptsNumber(user, 0);
        }

    }
}
