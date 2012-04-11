using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLibrary.Repository;
using ConsoleLibrary.ConsoleClasses;
using ConsoleLibrary.Interfaces;


namespace ConsoleLibrary.Implementation
{
    public class Account : IAccount
    {

        public ConsoleClasses.AccountConsole CreateAccount(string FirstName, string MiddleName, string LastName, string Address, string City, string Province, int ZipCode, int TelephoneNumber, int MobileNumber, string Email)
        {
            Contact_Repository acctRepo = new Contact_Repository();
            AccountConsole consoles = null;
            try
            {
                consoles = AccountConsole.TblToData(acctRepo.CreateAccount(FirstName,MiddleName,LastName,Address,City,Province,ZipCode,TelephoneNumber,MobileNumber,Email));

                if (consoles == null) throw new Exception("Error in Creating an Account");

                
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            return consoles;
        }

        public ConsoleClasses.AccountConsole UpdateAccount(string AccountID, string FirstName, string MiddleName, string LastName, string Address, string City, string Province,int ZipCode,int TelephoneNumber,int MobileNumber, string Email)
        {

            try
            {
                Contact_Repository acctRepo = new Contact_Repository();
                AccountConsole consoles = AccountConsole.TblToData(acctRepo.UpdateAccount(AccountID,FirstName,MiddleName,LastName,Address,City,Province,ZipCode,TelephoneNumber,MobileNumber,Email));
                 
                return consoles;

            }
            catch (Exception)
            {
                
                throw;
            }


            
        }

        public AccountConsole DeleteAccount(string AccountID)
        {
            try 
	        {	        
		            Contact_Repository acctRepo = new Contact_Repository();
                    AccountConsole consoles = AccountConsole.TblToData(acctRepo.DeleteAccount(AccountID));
                    return consoles;
	        }
	        catch (Exception)
	        {
		
		        throw;
	        }
        }






        public AllContacts GetAllContacts()
        {
            try
            {
                AllContacts objContacts = new AllContacts();
                Contact_Repository companyRepo = new Contact_Repository();
                objContacts.Contacts = AccountConsole.TblToData(companyRepo.GetContacts());

                return objContacts;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
