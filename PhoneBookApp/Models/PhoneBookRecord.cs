using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Models
{
    public class PhoneBookRecord : IRecord
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string PhoneNumber { get; }
        public string Separator { get; }

        public PhoneBookRecord(string firstName, string lastName, string phoneNumber, string separator)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Separator = separator;
        }

        public PhoneBookRecord(string firstName, string phoneNumber, string separator)
        {
            FirstName = firstName;
            PhoneNumber = phoneNumber;
            Separator = separator;
        }
    }
}
