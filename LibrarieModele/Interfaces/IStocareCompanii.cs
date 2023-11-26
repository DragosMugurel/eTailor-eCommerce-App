using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareCompanii : IStocareFactory
    {
        List<Companie> GetCompanii();
        Companie GetCompanie(int id);
        bool AddCompanie(Companie c);

        bool UpdateCompanie(Companie c);
    }
}
