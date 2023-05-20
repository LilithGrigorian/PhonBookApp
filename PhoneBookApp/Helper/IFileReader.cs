using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.Helper
{
    public interface IFileReader
    {
        string[] ReadAllLines(string filePath);
    }
}
