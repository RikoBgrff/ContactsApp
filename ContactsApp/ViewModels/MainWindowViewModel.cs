using ContactsApp.Models;
using ContactsApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace ContactsApp.ViewModels
{
    public class MainWindowViewModel:INotifyPropertyChanged
    {
        #region PropertiesRegion 
        public ObservableCollection<Contact> Contacts { get; set; }
        #endregion
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
        public MainWindowViewModel()
        {
            GetContacts getContacts = new GetContacts();
            Contacts = getContacts.GetContactsFromDb();
        }
    }
}