using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class OrdersAccessor
    {
        private readonly ETailorEntities context;

        public OrdersAccessor(ETailorEntities dbContext)
        {
            context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void DisplayOrders()
        {
            Console.WriteLine("--- Orders ---");
            var orders = context.Orders.ToList();
            DisplayCollection(orders, Console.WriteLine);

            // Use null-conditional operator to avoid null reference exception
            Console.WriteLine(orders.FirstOrDefault()?.order_id);
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
