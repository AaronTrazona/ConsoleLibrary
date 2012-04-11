using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLibrary.Repository;
using ConsoleLibrary;

namespace ConsoleApp.ConsoleClasses
{
    public class Contact
    {
        
        public string AccountID;     
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string Address;
        public string City; 
        public string Province;
        public int ZipCode;
        public int TelephoneNumber;
        public int MobileNumber;
        public string Email;
        public DateTime TimeSubmitted;

        public static Contact TblToData(tbl_ContactDB tblContactDB)
        {
            if (tblContactDB == null) return null;

            Contact account= new Contact();
            try
            {
                
               
                Console.WriteLine(string.Format("{0,-30}", "\t\tAccountID      : " + tblContactDB.AccountID + "\n"));
                Console.WriteLine(string.Format("{0,-30}", "\t\tFirstName      : " + tblContactDB.FirstName));
                Console.WriteLine(string.Format("{0,-30}", "\t\tMiddleName     : " + tblContactDB.MiddleName));
                Console.WriteLine(string.Format("{0,-30}", "\t\tLastName       : " + tblContactDB.LastName));
                Console.WriteLine(string.Format("{0,-30}", "\t\tAddress        : " + tblContactDB.Address));
                Console.WriteLine(string.Format("{0,-30}", "\t\tCity           : " + tblContactDB.City));
                Console.WriteLine(string.Format("{0,-30}", "\t\tProvince       : " + tblContactDB.Province));
                Console.WriteLine(string.Format("{0,-30}", "\t\tZipCode        : " + (int)tblContactDB.ZipCode));
                Console.WriteLine(string.Format("{0,-30}", "\t\tTelephoneNumber: " + (int)tblContactDB.TelephoneNumber));
                Console.WriteLine(string.Format("{0,-30}", "\t\tMobileNumber   : " + (int)tblContactDB.MobileNumber));
                Console.WriteLine(string.Format("{0,-30}", "\t\tEmail          : " + tblContactDB.Email));
                Console.WriteLine(string.Format("{0,-30}", "\t\tTimeSubmitted  : " + (DateTime)tblContactDB.TimeSubmitted + "\n\n"));


            }
            catch (Exception)
            {
                throw;
            }

            return account;
        }

        public static List<Contact> TblToData(List<tbl_ContactDB> tblContactDB)
        {
            List<Contact> account = new List<Contact>();

            try
            {
                if (tblContactDB == null) return null;
                tblContactDB.ForEach(delegate(tbl_ContactDB consoles)
                {
                    
                    Contact temp = TblToData(consoles);
                    if (temp != null)
                        account.Add(temp);
                    
                });

            }
            catch (Exception)
            {
                throw;
            }

            return account;
        }



       
    }
}
