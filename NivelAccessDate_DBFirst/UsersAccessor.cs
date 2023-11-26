using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class UsersAccessor
    {
        private readonly eTailorEntities context;

        public UsersAccessor(eTailorEntities dbContext)
        {
            context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void DisplayUsers()
        {
            Console.WriteLine("--- Users ---");
            var users = context.Users.ToList();
            DisplayCollection(users, Console.WriteLine);
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
