using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PhoneBookApp.Helper;
using PhoneBookApp.Models;
using PhoneBookApp.Services;
using PhoneBookApp.Validators;

namespace PhoneBookApp
{
    class PhoneBookWork
    {
        private readonly IPhoneBookValidator phoneBookValidator;
        private readonly IPhoneBookService phoneBookService;

        public PhoneBookWork(IPhoneBookValidator phoneBookValidator, IPhoneBookService phoneBookService)
        {
            this.phoneBookValidator = phoneBookValidator;
            this.phoneBookService = phoneBookService;
        }

        public void Start()
        {
            ConsoleHelper.DisplayMessage("Please enter the file path:");
            string filePath = ConsoleHelper.GetUserInput();

            List<IRecord> records = phoneBookService.ReadRecordsFromFile(filePath);

            ConsoleHelper.DisplayMessage("Please choose an ordering to sort: “Ascending” or “Descending”");
            var ordering = ConsoleHelper.GetUserInput();
            ConsoleHelper.DisplayMessage("Please choose criteria: “Name”, “Surname” or “PhoneNumberCode”");
            var criteria = ConsoleHelper.GetUserInput();

            records = phoneBookService.SortRecords(records, criteria, ordering);

            phoneBookService.PrintSortedRecords(records);
            Console.WriteLine();

            phoneBookValidator.PrintValidations(records);
            Console.WriteLine();

            ConsoleHelper.DisplayMessage("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
