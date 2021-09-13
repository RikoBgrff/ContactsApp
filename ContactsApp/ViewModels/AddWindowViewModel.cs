using ContactsApp.Command;
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
    public class AddWindowViewModel : INotifyPropertyChanged
    {
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

        public RelayCommand AddCommand { get; set; }
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
        public AddWindowViewModel()
        {
            this.AddCommand = new RelayCommand((c) =>
            {

                if (!string.IsNullOrEmpty(PhoneNumber))
                {
                    var connectionString = ConfigurationManager.ConnectionStrings["ContactsBook"].ConnectionString;
                    using SqlConnection connection = new SqlConnection();
                    connection.ConnectionString = connectionString;
                    connection.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandText = $"INSERT INTO Contacts(Name,Surname,Number) values ('{Name}','{Surname}','{PhoneNumber}')";
                    var data = command.ExecuteReader();
                    MessageBox.Show("Contact added sucsessfully!", "Information", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.Yes, MessageBoxOptions.ServiceNotification);
                }
            });
        }
    }
}
