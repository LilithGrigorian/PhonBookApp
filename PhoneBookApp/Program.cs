using Microsoft.Extensions.DependencyInjection;
using PhoneBookApp.Helper;
using PhoneBookApp.Services;
using PhoneBookApp.Validators;
using System;

namespace PhoneBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileReader, FileReader>()
                .AddSingleton<IPhoneBookValidator, PhoneBookValidator>()
                .AddSingleton<IPhoneBookService, PhoneBookService>()
                .AddSingleton<PhoneBookWork>()
                .BuildServiceProvider();

            var phoneBookWork = serviceProvider.GetService<PhoneBookWork>();

            phoneBookWork.Start();
        }
    }
}