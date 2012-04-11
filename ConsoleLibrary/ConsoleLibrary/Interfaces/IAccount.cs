using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLibrary.ConsoleClasses;

namespace ConsoleLibrary.Interfaces
{
    public interface IAccount
    {
       AccountConsole CreateAccount(string FirstName,
            string MiddleName,
            string LastName,
            string Address,
            string City,
            string Province,
            int ZipCode,
            int TelephoneNumber,
            int MobileNumber,
            string Email);

       AccountConsole UpdateAccount(string AccountID,
            string FirstName,
            string MiddleName,
            string LastName,
            string Address,
            string City,
            string Province,
            int ZipCode,
            int TelephoneNumber,
            int MobileNumber,
            string Email);
       AccountConsole DeleteAccount(string AccountID);
       AllContacts GetAllContacts();
    }
}
