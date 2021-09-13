using ContactsApp.Models;
using ContactsApp.Services;
using ContactsApp.ViewModels;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = new MainWindowViewModel();
            InitializeComponent();
          
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddWindow view = new AddWindow();
            view.ShowDialog();
            GetContacts getContacts = new GetContacts();
            ContactsListView.ItemsSource = getContacts.GetContactsFromDb();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var selectedItem = ContactsListView.SelectedItem as Contact;
            if (selectedItem == null)
            {
                MessageBox.Show("Select contact and try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (selectedItem != null)
            {
                EditWindow view = new EditWindow(selectedItem);
                view.ShowDialog();
                GetContacts getContacts = new GetContacts();
                ContactsListView.ItemsSource = getContacts.GetContactsFromDb();

            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var selectedItem = ContactsListView.SelectedItem as Contact;
            try
            {
                RemoveContact remover = new RemoveContact();
                if (selectedItem != null)
                {
                    remover.RemoveContactFromDatabase(selectedItem);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (selectedItem == null)
                {
                    MessageBox.Show("Select book and try again", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            GetContacts getContacts = new GetContacts();
            ContactsListView.ItemsSource = getContacts.GetContactsFromDb();
        }
    }
}