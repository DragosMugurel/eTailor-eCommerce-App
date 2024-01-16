using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class OrdersHistoryAccessor(ETailorEntities dbContext)
    {
        private readonly ETailorEntities context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public void DisplayOrdersHistory()
        {
            Console.WriteLine("--- Orders History ---");
            var ordersHistory = context.Order_history.ToList();
            DisplayCollection(ordersHistory, Console.WriteLine);

            // Use null-conditional operator to avoid null reference exception
            Console.WriteLine(ordersHistory.FirstOrDefault()?.order_id);
            Console.WriteLine(ordersHistory.FirstOrDefault()?.order_date);
            Console.WriteLine(ordersHistory.FirstOrDefault()?.order_status);
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
