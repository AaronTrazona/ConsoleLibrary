using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLibrary.Repository;
using System.Runtime.Serialization;


namespace ConsoleLibrary.ConsoleClasses
{
    [DataContract]
    public class AccountConsole
    {
        [DataMember]
        public string AccountID;
        [DataMember]
        public string FirstName;
        [DataMember]
        public string MiddleName;
        [DataMember]
        public string LastName;
        [DataMember]
        public string Address;
        [DataMember]
        public string City;
        [DataMember]
        public string Province;
        [DataMember]
        public int ZipCode;
        [DataMember]
        public int TelephoneNumber;
        [DataMember]
        public int MobileNumber;
        [DataMember]
        public string Email;
        [DataMember]
        public DateTime TimeSubmitted;


        public static AccountConsole TblToData(tbl_ContactDB tblContactDB) 
        {
            if (tblContactDB == null) return null;
            AccountConsole console = new AccountConsole();

            try
            {

                console.AccountID = tblContactDB.AccountID;
                console.FirstName = tblContactDB.FirstName;
                console.MiddleName = tblContactDB.MiddleName;
                console.LastName = tblContactDB.LastName;
                console.Address = tblContactDB.Address;
                console.City = tblContactDB.City;
                console.Province = tblContactDB.Province;
                console.ZipCode = (int)tblContactDB.ZipCode;
                console.TelephoneNumber = (int)tblContactDB.TelephoneNumber;
                console.MobileNumber = (int)tblContactDB.MobileNumber;
                console.Email = tblContactDB.Email;
                console.TimeSubmitted = (DateTime)tblContactDB.TimeSubmitted;

            }
            catch (Exception)
            {
                throw;
            }

            return console;
        }
  
     public static List<AccountConsole> TblToData(List<tbl_ContactDB> tblContactDB) 
     {
         List<AccountConsole> console = new List<AccountConsole>();

         try
         {
             if (tblContactDB == null) return null;
             tblContactDB.ForEach(delegate(tbl_ContactDB consoles)
             {
                 AccountConsole temp = TblToData(consoles);
                 if (temp != null)
                     console.Add(temp);

             });

         }
         catch (Exception) 
         {
             throw;
         }

         return console;
     }
    
    }
}
