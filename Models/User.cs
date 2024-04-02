using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Pin { get; set; }
        public bool IsAdmin { get; set; }
        public string CreditCardNumber { get; set; }
        public int AttemptsNumber { get; set; }
        public bool IsBlocked { get; set; }
        public double Ballance { get; set; }

        public User(long id, string name, string lastName, int pin, bool isAdmin,
            string creditCardNumber, int attemptsNumber, bool isBlocked, double ballance)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Pin = pin;
            IsAdmin = isAdmin;
            CreditCardNumber = creditCardNumber;
            AttemptsNumber = attemptsNumber;
            IsBlocked = isBlocked;
            Ballance = ballance;
        }
    }

}
