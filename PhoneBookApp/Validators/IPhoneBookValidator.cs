using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Validators
{
    internal interface IPhoneBookValidator
    {
        public void PrintValidations(List<IRecord> records);
    }
}
