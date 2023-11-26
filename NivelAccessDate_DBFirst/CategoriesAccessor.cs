using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class CategoriesAccessor
    {
        private readonly eTailorEntities context;

        public CategoriesAccessor(eTailorEntities dbContext)
        {
            context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void DisplayCategories()
        {
            Console.WriteLine("--- Categories ---");
            var categories = context.Categories.ToList();
            DisplayCollection(categories, Console.WriteLine);
            Console.WriteLine(categories.FirstOrDefault()?.category_name);
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
