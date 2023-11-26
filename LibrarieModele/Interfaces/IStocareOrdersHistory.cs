using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareOrdersHistory : IStocareFactory
    {
        List<Order_History> GetOrdersHistory();
        Order_History GetOrder_History(int id);
        bool AddOrder_History(Order_History ord);

        bool UpdateOrder_History(Order_History ord);
    }
}
