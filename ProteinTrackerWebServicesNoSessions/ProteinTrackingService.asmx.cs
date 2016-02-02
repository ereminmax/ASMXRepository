using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProteinTrackerWebServicesNoSessions
{
    [WebService(Namespace = "http://onebigmotherfucker.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class ProteinTrackingService : System.Web.Services.WebService
    {
        private UserRepository repository = new UserRepository();

        [WebMethod(Description = "Добавить число в значение Total", EnableSession = true)]
        public int AddProtein(int amount, int userId)
        {
            var user = repository.GetById(userId);
            if (user == null)
                return -1;
            
            user.Total += amount;
            repository.Save(user);
            return user.Total;
        }

        [WebMethod(Description = "Добавить пользователя", EnableSession = true)]
        public int AddUser(string name, int goal)
        {
            var user = new User {Goal = goal, Name = name, Total = 0};
            repository.Add(user);
            return user.UserId;
        }

        [WebMethod(Description = "Просмотреть пользователей", EnableSession = true)]
        public List<User> ListUsers()
        {
            return new List<User>(repository.GetAll());
        }
    }
}
