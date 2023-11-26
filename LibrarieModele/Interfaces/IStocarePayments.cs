using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocarePayments : IStocareFactory
    {
        List<Payment> GetPayments();
        Payment GetPayment(int id);
        bool AddPayment(Payment pay);
        bool UpdatePayment(Payment pay);
    }
}
