using ATM.Models;
using ATM.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Repository
{
    public class UserRepository
    {
        private List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
            _users = LoadUsers();
        }

        public List<User> LoadUsers()
        {
            string filePath = "../../Resources/Data/Users.json";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("JSON file not found.", filePath);
            }
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<User>>(jsonContent);
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

        public void Block(User user)
        {
            user.IsBlocked = true;
        }

        public void Unblock(User user)
        {
            user.IsBlocked = false;
        }
    }
}
