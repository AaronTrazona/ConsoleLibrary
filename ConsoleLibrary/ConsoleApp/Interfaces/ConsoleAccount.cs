using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp.ConsoleClasses;

namespace ConsoleApp.Interfaces
{
    public interface ConsoleAccount
    {
        Contact CreateAccount(string FirstName,
                string MiddleName,
                string LastName,
                string Address,
                string City,
                string Province,
                int ZipCode,
                int TelephoneNumber,
                int MobileNumber,
                string Email);

        AllAccount GetUpdate(string AccountID);
        Contact DeleteAccount(string AccountID);
        AllAccount GetAllContact();
    }
}
