using ATM.Models;
using ATM.Properties;
using Microsoft.Extensions.Configuration;
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
    public class UserRepository
    {
        private readonly NpgsqlConnection _connection;
        private List<User> _users;

        public UserRepository()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _connection = new NpgsqlConnection(connectionString);
            _users = new List<User>();
            _users = LoadUsers();
        }

        public List<User> LoadUsers()
        {
            _users = new List<User>();

            try
            {
                _connection.Open();
                string sql = "SELECT * FROM public.\"User\"";

                using (NpgsqlCommand command = new NpgsqlCommand(sql, _connection))
                {
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            User user = new User(
                                Convert.ToInt64(reader["Id"]),
                                Convert.ToString(reader["Name"]).Trim(),
                                Convert.ToString(reader["LastName"]).Trim(),
                                Convert.ToInt32(reader["Pin"]),
                                Convert.ToBoolean(reader["IsAdmin"]),
                                Convert.ToString(reader["CreditCardNumber"]).Trim(),
                                Convert.ToInt32(reader["AttemptsNumber"]),
                                Convert.ToBoolean(reader["IsBlocked"]),
                                Convert.ToDouble(reader["Ballance"])
                            );
                            _users.Add(user);
                        }
                    }
                }
            }
            finally
            {
                _connection.Close();
            }

            return _users;
        }

        public List<User> LoadAllBlocked()
        {
            return _users.Where(u => u.IsBlocked && !u.IsAdmin).ToList();
        }

        public User GetUserByCard(string card)
        {
            return _users.FirstOrDefault(u => u.CreditCardNumber == card);
        }

        public List<int> GetAllPins()
        {
            return _users.Select(u => u.Pin).ToList();
        }

        public List<long> GetAllIds()
        {
            return _users.Select(u => u.Id).ToList();
        }

        public void Add(User user)
        {
            try
            {
                _connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandText = "INSERT INTO public.\"User\" " +
                                          "(\"Id\", \"Name\", \"LastName\", \"Pin\", \"IsAdmin\", \"CreditCardNumber\", " +
                                          "\"AttemptsNumber\", \"IsBlocked\", \"Ballance\") " +
                                          "VALUES (@Id, @Name, @LastName, @Pin, @IsAdmin, @CreditCardNumber, " +
                                          "@AttemptsNumber, @IsBlocked, @Ballance)";
                    command.Parameters.AddWithValue("Id", user.Id);
                    command.Parameters.AddWithValue("Name", user.Name);
                    command.Parameters.AddWithValue("LastName", user.LastName);
                    command.Parameters.AddWithValue("Pin", user.Pin);
                    command.Parameters.AddWithValue("IsAdmin", user.IsAdmin);
                    command.Parameters.AddWithValue("CreditCardNumber", user.CreditCardNumber);
                    command.Parameters.AddWithValue("AttemptsNumber", user.AttemptsNumber);
                    command.Parameters.AddWithValue("IsBlocked", user.IsBlocked);
                    command.Parameters.AddWithValue("Ballance", user.Ballance);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public void SaveChanges(User user)
        {
            try
            {
                _connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandText = "UPDATE public.\"User\" " +
                                          "SET \"Name\" = @Name, " +
                                              "\"LastName\" = @LastName, " +
                                              "\"CreditCardNumber\" = @CreditCardNumber, " +
                                              "\"IsBlocked\" = @IsBlocked, " +
                                              "\"Ballance\" = @Ballance " +
                                          "WHERE \"Id\" = @Id";
                    command.Parameters.AddWithValue("Name", user.Name);
                    command.Parameters.AddWithValue("LastName", user.LastName);
                    command.Parameters.AddWithValue("CreditCardNumber", user.CreditCardNumber);
                    command.Parameters.AddWithValue("IsBlocked", user.IsBlocked);
                    command.Parameters.AddWithValue("Ballance", user.Ballance);
                    command.Parameters.AddWithValue("Id", user.Id);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public void SaveLogInAttempts(User user, int attempts)
        {
            try
            {
                _connection.Open();
                using (NpgsqlCommand command = new NpgsqlCommand())
                {
                    command.Connection = _connection;
                    command.CommandText = "UPDATE public.\"User\" " +
                                          "SET \"AttemptsNumber\" = @Attempts " +
                                          "WHERE \"Id\" = @Id";
                    command.Parameters.AddWithValue("Attempts", attempts);
                    command.Parameters.AddWithValue("Id", user.Id);

                    command.ExecuteNonQuery();
                }
            }
            finally
            {
                _connection.Close();
            }
        }

        public bool CheckForCardNumber(string cardNumber)
        {
            foreach (var user in _users)
            {
                if (user.CreditCardNumber == cardNumber)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
