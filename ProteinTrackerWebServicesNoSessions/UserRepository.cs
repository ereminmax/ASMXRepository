using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace ProteinTrackerWebServicesNoSessions
{
    public interface IUserRepository
    {
        void Add(User user);
        ReadOnlyCollection<User> GetAll();
        User GetById(int id);
        void Save(User updatedUser);
    }

    public class UserRepository : IUserRepository
    {
        private static readonly List<User> users = new List<User>();
        private static int nextId = 0;

        public void Add(User user)
        {
            user.UserId = nextId;
            nextId++;
            users.Add(user);
        }

        public ReadOnlyCollection<User> GetAll()
        {
            return users.AsReadOnly();
        }

        public User GetById(int id)
        {
            var user = users.SingleOrDefault(u => u.UserId == id);
            if (user == null)
                return null;
            return new User {Goal = user.Goal, Name = user.Name, Total = user.Total, UserId = user.UserId};
        }

        public void Save(User updatedUser)
        {
            var originalUser = users.SingleOrDefault(u => u.UserId == updatedUser.UserId);
            if (originalUser == null)
                return;
            originalUser.Name = updatedUser.Name;
            originalUser.Total = updatedUser.Total;
            originalUser.Goal = updatedUser.Goal;
        }
    }
}