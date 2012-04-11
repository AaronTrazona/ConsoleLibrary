using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp.Interfaces;
using ConsoleApp.ConsoleClasses;
using ConsoleLibrary.Repository;

namespace ConsoleApp.Implementation
{
    public class FunctionClasses : ConsoleAccount
    {

        public ConsoleClasses.Contact CreateAccount(string FirstName, string MiddleName, string LastName, string Address, string City, string Province, int ZipCode, int TelephoneNumber, int MobileNumber, string Email)
        {
            throw new NotImplementedException();
        }
    
        public ConsoleClasses.Contact DeleteAccount(string AccountID)
        {
            throw new NotImplementedException();
        }

        public ConsoleClasses.AllAccount GetAllContact()
        {
            try
            {
                AllAccount objContacts = new AllAccount();
                Contact_Repository companyRepo = new Contact_Repository();
                objContacts.Contacts  = Contact.TblToData(companyRepo.GetContacts());

                return objContacts;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public AllAccount GetUpdate(string AccountID)
        {
            AllAccount objcontacts = new AllAccount();
            Contact_Repository acctRepo = new Contact_Repository();
            objcontacts.singleContact = Contact.TblToData(acctRepo.GetUpdate(AccountID));

            if (objcontacts.singleContact == null) return null;
            return objcontacts;
             
        }

        
    }
}
