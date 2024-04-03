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
            //string filePath = "../../Resources/Data/Users.json";
            //if (!File.Exists(filePath))
            //{
            //    throw new FileNotFoundException("JSON file not found.", filePath);
            //}
            //string jsonContent = File.ReadAllText(filePath);
            //return JsonConvert.DeserializeObject<List<User>>(jsonContent);
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
            _users.Add(user);
            Save();
        }

        public void Save()
        {
            string json = JsonConvert.SerializeObject(_users);
            File.WriteAllText("../../Resources/Data/Users.json", json);


            //try
            //{
            //    _connection.Open();
            //    using (var transaction = _connection.BeginTransaction())
            //    {
            //        try
            //        {
            //            var deleteCommand = new NpgsqlCommand("DELETE FROM public.\"User\"", _connection);
            //            deleteCommand.ExecuteNonQuery();

            //            foreach (var user in _users)
            //            {
            //                var insertCommand = new NpgsqlCommand(
            //                    "INSERT INTO public.\"User\" (\"Id\", \"Name\", \"LastName\", \"Pin\", \"IsAdmin\", \"CreditCardNumber\", \"AttemptsNumber\", \"IsBlocked\", \"Balance\") " +
            //                    "VALUES (@Id, @Name, @LastName, @Pin, @IsAdmin, @CreditCardNumber, @AttemptsNumber, @IsBlocked, @Balance)", _connection);
            //                insertCommand.Parameters.AddWithValue("@Id", user.Id);
            //                insertCommand.Parameters.AddWithValue("@Name", user.Name);
            //                insertCommand.Parameters.AddWithValue("@LastName", user.LastName);
            //                insertCommand.Parameters.AddWithValue("@Pin", user.Pin);
            //                insertCommand.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            //                insertCommand.Parameters.AddWithValue("@CreditCardNumber", user.CreditCardNumber);
            //                insertCommand.Parameters.AddWithValue("@AttemptsNumber", user.AttemptsNumber);
            //                insertCommand.Parameters.AddWithValue("@IsBlocked", user.IsBlocked);
            //                insertCommand.Parameters.AddWithValue("@Ballance", user.Ballance);

            //                insertCommand.ExecuteNonQuery();
            //            }

            //            transaction.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            transaction.Rollback();
            //            throw new Exception("Error while saving users to database.", ex);
            //        }
            //    }
            //}
            //finally
            //{
            //    _connection.Close();
            //}
        }

        public void SaveChanges(User user)
        {
            _users = LoadUsers();

            User existingUser = _users.FirstOrDefault(u => u.Id == user.Id);

            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            existingUser.CreditCardNumber = user.CreditCardNumber;
            existingUser.IsBlocked = user.IsBlocked;
            existingUser.Ballance = user.Ballance;
            Save();
        }

        public void SaveLogInAttempts(User user, int attempts)
        {
            _users = LoadUsers();

            User existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            existingUser.AttemptsNumber = attempts;
            Save();
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
