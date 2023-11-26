using LibrarieModele;

using System.Collections.Generic;

namespace LibrarieModele_Interfete
{
    public interface IStocareUsers : IStocareFactory
    {
        List<User> GetUsers();
        User GetUser(int id);
        bool AddUser(User u);
        bool UpdateUser(User u);
    }
}
