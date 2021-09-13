using ContactsApp.Command;
using ContactsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;

namespace ContactsApp.ViewModels
{
    public class EditWindowViewModel : INotifyPropertyChanged
    {

        public EditWindowViewModel(Contact contact)
        {
            Name = contact.Name;
            Surname = contact.Surname;
            PhoneNumber = contact.PhoneNumber;
            this.EditCommand = new RelayCommand((c) =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["ContactsBook"].ConnectionString;
                using SqlConnection connection = new SqlConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = $"UPDATE Contacts SET Name = '{Name}',Surname = '{Surname}',Number='{PhoneNumber}' WHERE Id={contact.Id}";
                var data = command.ExecuteNonQuery();
                MessageBox.Show("Contact updated sucsessfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.ServiceNotification);

            });

        }
        #region PropertiesRegion
        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        private string surname;
        public string Surname
        {
            get
            {
                return surname;
            }

            set
            {
                surname = value;
                OnPropertyChanged();
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }

            set
            {
                phoneNumber = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand EditCommand { get; set; }
        #endregion PropertyRegion

        #region InterfaceImplemented
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion InterfaceImplemented
   

    }
}
