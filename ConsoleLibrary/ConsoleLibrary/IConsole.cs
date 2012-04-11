using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLibrary.ConsoleClasses;
using ConsoleLibrary.Interfaces;
using System.ServiceModel;

namespace ConsoleLibrary
{
    [ServiceContract]
    public interface IConsole : IAccount
    {
        [OperationContract]

        new AccountConsole CreateAccount(string FirstName,
            string MiddleName,
            string LastName,
            string Address,
            string City,
            string Province,
            int ZipCode,
            int TelephoneNumber,
            int MobileNumber,
            string Email);
        [OperationContract]    
        new AccountConsole UpdateAccount(string AccountID,
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
        [OperationContract]
        new AccountConsole DeleteAccount(string AccountID);
        [OperationContract]
        new AllContacts GetAllContacts();


    }
}
