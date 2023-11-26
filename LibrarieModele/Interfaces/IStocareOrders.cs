using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareOrders : IStocareFactory
    {
        List<Order> GetOrders();
        Order GetOrders(int id);
        bool AddOrder(Order o);

        bool UpdateOrder(Order o);
    }
}
