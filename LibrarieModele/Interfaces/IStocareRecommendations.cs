using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareRecommendations : IStocareFactory
    {
        List<Recommendation> GetRecommendations();
        Recommendation GetRecommendation(int id);
        bool AddRecommendation(Recommendation r);
        bool UpdateRecommendation(Recommendation r);
    }
}
