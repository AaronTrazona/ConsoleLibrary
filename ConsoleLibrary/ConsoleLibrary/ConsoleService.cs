using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLibrary.ConsoleClasses;
using ConsoleLibrary.Repository;
using ConsoleLibrary.Implementation;
using System.ServiceModel;

namespace ConsoleLibrary
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class ConsoleService : IConsole
    {
        public AccountConsole CreateAccount(string FirstName, string MiddleName, string LastName, string Address, string City, string Province, int ZipCode, int TelephoneNumber, int MobileNumber, string Email)
        {
            Account account = new Account();
            return account.CreateAccount(FirstName, MiddleName, LastName, Address, City, Province, ZipCode, TelephoneNumber, MobileNumber, Email);
        }

        public AccountConsole UpdateAccount(string AccountID, string FirstName, string MiddleName, string LastName, string Address, string City, string Province, int ZipCode, int TelephoneNumber, int MobileNumber, string Email)
        {
            Account account = new Account();
            return account.UpdateAccount(AccountID,FirstName, MiddleName, LastName, Address, City, Province, ZipCode, TelephoneNumber, MobileNumber, Email);
        }
        public AccountConsole DeleteAccount(string AccountID)
        {
            Account account = new Account();
            return account.DeleteAccount(AccountID);
        }

        public AllContacts GetAllContacts()
        {
            Account account = new Account();
            return account.GetAllContacts();
            
        }
    }
}
