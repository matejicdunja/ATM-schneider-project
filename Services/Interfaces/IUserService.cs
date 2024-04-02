using ATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Services.Interfaces
{
    public interface IUserService
    {
        bool GenerateReport(User user);
        long GenerateId();
        int GeneratePin();
        User Register(string name, string lastName, string creditCardNumber);
        User FindCardNumber(string card);
        bool SignIn(User user, int pin);
        long GenerateTransactionId();
        void TopUp(User user, double amount);
        void Withdraw(User user, double amount);
        void EditProfile(User user, string name, string surname, string card);
        void UpdateLogInAttemptsNumber(User user, int attempts);
        List<User> GetBlockedUsers();
        void BlockUser(User user);
        void UnblockUser(User user);
    }
}
