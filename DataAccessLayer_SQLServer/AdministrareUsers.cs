using LibrarieModele;

using LibrarieModele_Interfete;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NivelAccesDate_SQLServer
{
    public class AdministrareUsers : IStocareUsers
    {
        private const int PRIMUL_TABEL = 0;
        private const int PRIMA_LINIE = 0;

        public List<User> GetUsers()
        {
            var result = new List<User>();
            var dsUsers = SqlDBHelper.ExecuteDataSet("select * from dbo.Users", CommandType.Text);

            foreach (DataRow linieBD in dsUsers.Tables[PRIMUL_TABEL].Rows)
            {
                var user = new User(linieBD);
                //incarca entitatile aditionale
                //masina.Companie = new AdministrareCompanii().GetCompanie(masina.IdCompanie);
                result.Add(user);
            }
            return result;
        }

        public User GetUser(int id)
        {
            User result = null;
            var dsUsers = SqlDBHelper.ExecuteDataSet("select * from dbo.Users where User_Id = @User_Id", CommandType.Text,
                new SqlParameter("@User_Id", id));

            if (dsUsers.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsUsers.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new User(linieBD);
                //incarca entitatile aditionale
                //result.Companie = new AdministrareCompanii().GetCompanie(result.IdCompanie);
            }
            return result;
        }

        public bool AddUser(User u)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "insert into dbo.Users VALUES (@User_Id, @First_Name, @Last_Name, @Email, @Password, @Address, @City, @Postal_Code, @Country, @Phone_Number, @User_Type)", CommandType.Text,
                new SqlParameter("@User_Id", u.User_Id),
                new SqlParameter("@First_Name", u.First_Name),
                new SqlParameter("@Last_Name", u.Last_Name),
                new SqlParameter("@Email", u.Email),
                new SqlParameter("@Password", u.Password),
                new SqlParameter("@Address", u.Address),
                new SqlParameter("@City", u.City),
                new SqlParameter("@Postal_Code", u.Postal_Code),
                new SqlParameter("@Country", u.Country),
                new SqlParameter("@Phone_Number", u.Phone_Number),
                new SqlParameter("@User_Type", u.User_Type)
            );
        }

        public bool UpdateUser(User u)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Users set First_Name = @First_Name, Last_Name = @Last_Name, Email = @Email, Password = @Password, Address = @Address, City = @City, Postal_Code = @Postal_Code, Country = @Country, Phone_Number = @Phone_Number, User_Type = @User_Type where User_Id = @User_Id", CommandType.Text,
                 new SqlParameter("@User_Id", u.User_Id),
                 new SqlParameter("@First_Name", u.First_Name),
                 new SqlParameter("@Last_Name", u.Last_Name),
                 new SqlParameter("@Email", u.Email),
                 new SqlParameter("@Password", u.Password),
                 new SqlParameter("@Address", u.Address),
                 new SqlParameter("@City", u.City),
                 new SqlParameter("@Postal_Code", u.Postal_Code),
                 new SqlParameter("@Country", u.Country),
                 new SqlParameter("@Phone_Number", u.Phone_Number),
                 new SqlParameter("@User_Type", u.User_Type)
             );
        }

    }
}
