using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace ContactsApp.Services
{
    public class RemoveContact
    {
        public void RemoveContactFromDatabase(Contact contact)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["ContactsBook"].ConnectionString;
            using SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"Delete Contacts WHERE Id={contact.Id}";
            var data = command.ExecuteNonQuery();
            MessageBox.Show("Contact deleted sucsessfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.ServiceNotification);

        }

    }
}
