using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Transaction
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }

        public Transaction(long id, long userId, DateTime date, double amount)
        {
            Id = id;
            UserId = userId;
            Date = date;
            Amount = amount;
        }
    }
}
