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
            var dsUsers = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Users", CommandType.Text);

            foreach (DataRow linieBD in dsUsers.Tables[PRIMUL_TABEL].Rows)
            {
                var user = new User(linieBD);
                result.Add(user);
            }
            return result;
        }

        public User GetUser(int user_id)
        {
            User result = null;
            var dsUsers = SqlDBHelper.ExecuteDataSet("SELECT * FROM dbo.Users WHERE user_id = @user_id", CommandType.Text,
                new SqlParameter("@user_id", user_id));

            if (dsUsers.Tables[PRIMUL_TABEL].Rows.Count > 0)
            {
                DataRow linieBD = dsUsers.Tables[PRIMUL_TABEL].Rows[PRIMA_LINIE];
                result = new User(linieBD);
            }
            return result;
        }

        public bool AddUser(User u)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "INSERT INTO dbo.Users (user_id, first_name, last_name, email, password, address, city, postal_code, country, phone_number, user_type) VALUES (@user_id, @first_name, @last_name, @email, @password, @address, @city, @postal_code, @country, @phone_number, @user_type)", CommandType.Text,
                new SqlParameter("@user_id", u.User_Id),
                new SqlParameter("@first_name", u.First_Name),
                new SqlParameter("@last_name", u.Last_Name),
                new SqlParameter("@email", u.Email),
                new SqlParameter("@password", u.Password),
                new SqlParameter("@address", u.Address),
                new SqlParameter("@city", u.City),
                new SqlParameter("@postal_code", u.Postal_Code),
                new SqlParameter("@country", u.Country),
                new SqlParameter("@phone_number", u.Phone_Number),
                new SqlParameter("@user_type", u.User_Type)
            );
        }

        public bool UpdateUser(User u)
        {
            return SqlDBHelper.ExecuteNonQuery(
                "UPDATE dbo.Users SET first_name = @first_name, last_name = @last_name, email = @email, password = @password, address = @address, city = @city, postal_code = @postal_code, country = @country, phone_number = @phone_number, user_type = @user_type WHERE user_id = @user_id", CommandType.Text,
                new SqlParameter("@user_id", u.User_Id),
                new SqlParameter("@first_name", u.First_Name),
                new SqlParameter("@last_name", u.Last_Name),
                new SqlParameter("@email", u.Email),
                new SqlParameter("@password", u.Password),
                new SqlParameter("@address", u.Address),
                new SqlParameter("@city", u.City),
                new SqlParameter("@postal_code", u.Postal_Code),
                new SqlParameter("@country", u.Country),
                new SqlParameter("@phone_number", u.Phone_Number),
                new SqlParameter("@user_type", u.User_Type)
            );
        }
    }
}
