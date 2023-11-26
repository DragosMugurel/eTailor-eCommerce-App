using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace LibrarieModele
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postal_Code { get; set; }
        public string Country { get; set; }
        public string Phone_Number { get; set; }
        public string User_Type { get; set; }

        public User()
        { }

        public User(string first_name, string last_name, string email, string password, string address, string city, string postal_code, string country, string phone_number, string user_type, int user_id = 0)
        {
            User_Id = user_id;
            First_Name = first_name;
            Last_Name = last_name;
            Email = email;
            Password = password;
            Address = address;
            City = city;
            Postal_Code = postal_code;
            Country = country;
            Phone_Number = phone_number;
            User_Type = user_type;
        }

        public User(DataRow linieDB)
        {
            User_Id = Convert.ToInt32(linieDB["user_id"].ToString());
            First_Name = linieDB["first_name"].ToString();
            Last_Name = linieDB["last_name"].ToString();
            Email = linieDB["email"].ToString();
            Password = linieDB["password"].ToString();
            Address = linieDB["address"].ToString();
            City = linieDB["city"].ToString();
            Postal_Code = linieDB["postal_code"].ToString();
            Country = linieDB["country"].ToString();
            Phone_Number = linieDB["phone_number"].ToString();
            User_Type = linieDB["user_type"].ToString();
        }
    }
}
