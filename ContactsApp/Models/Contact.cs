using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"{Id} - {Name} - {Surname} - {PhoneNumber}";
        }
    }
}