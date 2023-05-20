using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBookApp.Models;

namespace PhoneBookApp.Services
{
    interface IPhoneBookService
    {
        List<IRecord> ReadRecordsFromFile(string filePath);

        List<IRecord> SortRecords(List<IRecord> records, string criteria, string ordering);

        void PrintSortedRecords(List<IRecord> sortedRecords);
    }
}
