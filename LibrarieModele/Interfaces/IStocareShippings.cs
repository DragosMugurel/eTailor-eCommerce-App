using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareShippings : IStocareFactory
    {
        List<Shipping> GetShippings();
        Shipping GetShipping(int id);
        bool AddShipping(Shipping sh);
        bool UpdateShipping(Shipping sh);
    }
}
