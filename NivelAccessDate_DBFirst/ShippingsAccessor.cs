using Repository_DBFirst;

using System;
using System.Collections.Generic;
using System.Linq;

namespace NivelAccesDate_DBFirst
{
    public class ShippingsAccessor
    {
        private readonly eTailorEntities context;

        public ShippingsAccessor(eTailorEntities dbContext)
        {
            context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void DisplayShippings()
        {
            Console.WriteLine("--- Shippings ---");
            var shippings = context.Shippings.ToList();
            DisplayCollection(shippings);

            // Use null-conditional operator to avoid null reference exception
            DisplayShippingProperty(shippings.FirstOrDefault(), s => s?.shipping_id);
            DisplayShippingProperty(shippings.FirstOrDefault(), s => s?.shipping_address);
            DisplayShippingProperty(shippings.FirstOrDefault(), s => s?.shipping_date);
        }

        private void DisplayCollection<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private void DisplayShippingProperty<T>(T shipping, Func<T, object> propertySelector)
        {
            Console.WriteLine(propertySelector(shipping));
        }
    }
}
