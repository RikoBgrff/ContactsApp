
using ContactsApp.Models;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace ContactsApp.Services
{
    public class GetContacts
    {
        public Contact Contact { get; set; } = new Contact();

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> GetContactsFromDb()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ContactsBook"].ConnectionString;
            using SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Contacts";
            var data = command.ExecuteReader();
            if (data.HasRows)
            {
                while (data.Read())
                {
                    //Contact.Id = data.GetInt32(0);
                    //Contact.Name = data.GetString(1);
                    //Contact.Surname = data.GetString(2);
                    //Contact.PhoneNumber = data.GetString(3);
                    Contacts.Add(
                        new Contact()
                        {
                            Id = data.GetInt32(0),
                            Name = data.GetString(1),
                            Surname = data.GetString(2),
                            PhoneNumber = data.GetString(3)
                        });
                }
                connection.Close();
            }
                return Contacts;
        }
    }
}
