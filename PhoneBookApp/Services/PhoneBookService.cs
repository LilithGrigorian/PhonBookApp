using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using PhoneBookApp.Helper;
using PhoneBookApp.Models;
using PhoneBookApp.Validators;

namespace PhoneBookApp.Services
{
    public class PhoneBookService : IPhoneBookService
    {
        private readonly IFileReader fileReader;

        public PhoneBookService(IFileReader fileReader)
        {
            this.fileReader = fileReader;
        }

        public List<IRecord> ReadRecordsFromFile(string filePath)
        {
            string[] lines = fileReader.ReadAllLines(filePath);
            List<IRecord> records = ParseRecords(lines);

            return records;
        }

        public List<IRecord> SortRecords(List<IRecord> records, string criteria, string ordering)
        {
            switch (criteria)
            {
                case "Name":
                    if (ordering == "Ascending")
                    {
                        records.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
                    }
                    else if (ordering == "Descending")
                    {
                        records.Sort((x, y) => string.Compare(y.FirstName, x.FirstName));
                    }
                    break;

                case "Surname":
                    if (ordering == "Ascending")
                    {
                        records.Sort((x, y) =>
                        {
                            if (string.IsNullOrEmpty(x.LastName) && !string.IsNullOrEmpty(y.LastName))
                                return 1;
                            else if (!string.IsNullOrEmpty(x.LastName) && string.IsNullOrEmpty(y.LastName))
                                return -1;
                            else if (string.IsNullOrEmpty(x.LastName) && string.IsNullOrEmpty(y.LastName))
                                return 0;
                            else
                                return string.Compare(x.LastName, y.LastName);
                        });
                    }
                    else if (ordering == "Descending")
                    {
                        records.Sort((x, y) =>
                        {
                            if (string.IsNullOrEmpty(x.LastName) && !string.IsNullOrEmpty(y.LastName))
                                return -1;
                            else if (!string.IsNullOrEmpty(x.LastName) && string.IsNullOrEmpty(y.LastName))
                                return 1;
                            else if (string.IsNullOrEmpty(x.LastName) && string.IsNullOrEmpty(y.LastName))
                                return 0;
                            else
                                return string.Compare(y.LastName, x.LastName);
                        });
                    }
                    break;

                case "PhoneNumberCode":
                    if (ordering == "Ascending")
                    {
                        records.Sort((x, y) => string.Compare(GetPhoneNumberCode(x.PhoneNumber), GetPhoneNumberCode(y.PhoneNumber)));
                    }
                    else if (ordering == "Descending")
                    {
                        records.Sort((x, y) => string.Compare(GetPhoneNumberCode(y.PhoneNumber), GetPhoneNumberCode(x.PhoneNumber)));
                    }
                    break;
            }

            return records;
        }

        private string GetPhoneNumberCode(string phoneNumber)
        {
            if (phoneNumber.Length >= 3)
            {
                return phoneNumber.Substring(0, 3);
            }
            return "";
        }

        private List<IRecord> ParseRecords(string[] lines)
        {
            List<IRecord> records = new List<IRecord>();

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');

                if (parts.Length > 3)
                {
                    string firstName = parts[0];
                    string lastName = parts[1];
                    string seperator = parts[2];
                    string phoneNumber = parts[3];

                    PhoneBookRecord record = new PhoneBookRecord(firstName, lastName, phoneNumber, seperator);

                    records.Add(record);
                }
                else
                {
                    string firstName = parts[0];
                    string seperator = parts[1];
                    string phoneNumber = parts[2];

                    PhoneBookRecord record = new PhoneBookRecord(firstName, phoneNumber, seperator);

                    records.Add(record);
                }
            }

            return records;
        }

        public void PrintSortedRecords(List<IRecord> sortedRecords)
        {
            foreach (var record in sortedRecords)
            {
                Console.WriteLine($"{record.FirstName} {record.LastName} {record.Separator} {record.PhoneNumber}");
            }
        }
    }
}
