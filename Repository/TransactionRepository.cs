using ATM.Models;
using Newtonsoft.Json;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Repository
{
    public class TransactionRepository
    {
        private readonly NpgsqlConnection _connection;
        private List<Transaction> _transactions;

        public TransactionRepository() 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new NpgsqlConnection(connectionString);
            _transactions = new List<Transaction>();
            _transactions = LoadTransactions();
        }

        public void Save(Transaction transaction)
        {
            try
            {
                _connection.Open();

                string query = "INSERT INTO public.\"Transaction\" " +
                    "(\"Id\", \"UserId\", \"Date\", \"Amount\") " +
                    "VALUES (@Id, @UserId, @Date, @Amount)";
                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@Id", transaction.Id);
                    command.Parameters.AddWithValue("@UserId", transaction.UserId);
                    command.Parameters.AddWithValue("@Date", transaction.Date);
                    command.Parameters.AddWithValue("@Amount", transaction.Amount);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving transaction: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }
        }

        private List<Transaction> LoadTransactions()
        {
            try
            {
                _connection.Open();

                string query = "SELECT * FROM public.\"Transaction\"";
                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Transaction transaction = new Transaction(
                                Convert.ToInt32(reader["Id"]),
                                Convert.ToInt32(reader["UserId"]),
                                Convert.ToDateTime(reader["Date"]),
                                Convert.ToDouble(reader["Amount"]));
                            _transactions.Add(transaction);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading transactions: " + ex.Message);
            }
            finally
            {
                _connection.Close();
            }

            return _transactions;
        }

        public List<long> GetAllIds()
        {
            return _transactions.Select(t => t.Id).ToList();
        }
    }
}
