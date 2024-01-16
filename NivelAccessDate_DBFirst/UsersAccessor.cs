using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class UsersAccessor
    {
        private readonly ETailorEntities context;

        public UsersAccessor(ETailorEntities dbContext)
        {
            context = dbContext;
        }

        public void DisplayUsers()
        {
            var users = context.Users.ToList();
            DisplayCollection(users, Console.WriteLine);
        }

        public bool LoginUser(string email, string password)
        {
            var user = context.Users.FirstOrDefault(u => u.email == email && u.password == password);
            return user != null;
        }

        private void DisplayCollection<T>(IEnumerable<T> collection, Action<T> displayAction)
        {
            foreach (var item in collection)
            {
                displayAction(item);
            }
        }
    }
}
