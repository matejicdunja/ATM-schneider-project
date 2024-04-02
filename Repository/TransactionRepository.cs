using ATM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Repository
{
    public class TransactionRepository
    {
        public TransactionRepository() { }

        public void Save(Transaction transaction)
        {
            try
            {
                List<Transaction> transactions = LoadTransactions();
                transactions.Add(transaction);
                SaveTransactions(transactions);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private List<Transaction> LoadTransactions()
        {
            try
            {
                string json = File.ReadAllText("../../Resources/Data/Transactions.json");
                List<Transaction> transactions = JsonConvert.DeserializeObject<List<Transaction>>(json);
                if (transactions != null)
                {
                    return transactions;
                }
                return new List<Transaction>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<Transaction>();
            }
        }

        private void SaveTransactions(List<Transaction> transactions)
        {
            try
            {
                string json = JsonConvert.SerializeObject(transactions, Formatting.Indented);
                File.WriteAllText("../../Resources/Data/Transactions.json", json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public List<long> GetAllIds()
        {
            List<Transaction> transactions = LoadTransactions();
            return transactions.Select(t => t.Id).ToList();
        }
    }
}
