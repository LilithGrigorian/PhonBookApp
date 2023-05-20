using PhoneBookApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Validators
{
    public class PhoneBookValidator : IPhoneBookValidator
    {
        public void PrintValidations(List<IRecord> records)
        {
            var validationMessage = String.Empty;

            for (int i = 0; i < records.Count; i++)
            {
                var record = records[i];

                if (!IsValidPhoneNumber(record.PhoneNumber))
                {
                    validationMessage = $"line {i + 1}: phone number should be with 9 digits.";
                    Console.WriteLine(validationMessage);
                }

                if (!IsValidSeparator(record.Separator))
                {
                    validationMessage = $"line {i + 1}: separator should be `:` or `-`.";
                    Console.WriteLine(validationMessage);
                }
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 9 && phoneNumber.All(char.IsDigit);
        }

        private bool IsValidSeparator(string separator)
        {
            return separator == ":" || separator == "-";
        }
    }
}

