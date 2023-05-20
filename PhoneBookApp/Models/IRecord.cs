using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Models
{
    public interface IRecord
    {
        string FirstName { get; }
        string LastName { get; }
        string PhoneNumber { get; }
        string Separator { get; }
    }
}
