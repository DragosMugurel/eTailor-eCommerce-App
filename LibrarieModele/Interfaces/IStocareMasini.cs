using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareMasini : IStocareFactory
    {
        List<Masina> GetMasini();
        Masina GetMasina(int id);
        bool AddMasina(Masina m);

        bool UpdateMasina(Masina m);
    }
}
