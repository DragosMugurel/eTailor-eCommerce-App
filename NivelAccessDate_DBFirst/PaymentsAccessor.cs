using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class PaymentsAccessor
    {
        private readonly eTailorEntities context;

        public PaymentsAccessor(eTailorEntities dbContext)
        {
            context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void DisplayPayments()
        {
            Console.WriteLine("--- Payments ---");
            var payments = context.Payments.ToList();
            DisplayCollection(payments);

            // Use null-conditional operator to avoid null reference exception
            Console.WriteLine(payments.FirstOrDefault()?.payment_id);
            Console.WriteLine(payments.FirstOrDefault()?.payment_date);
            Console.WriteLine(payments.FirstOrDefault()?.payment_method);
        }

        private void DisplayCollection<T>(List<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
