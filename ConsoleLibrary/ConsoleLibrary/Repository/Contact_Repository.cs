using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleLibrary.ConsoleClasses;
using System.Configuration;


namespace ConsoleLibrary.Repository
{
    public class Contact_Repository
    {
        private ConsoleDatabaseDataContext db = new ConsoleDatabaseDataContext();

        public string connectionString() 
        {
            return ConfigurationManager.ConnectionStrings["ConsoleLibrary.Properties.Settings.ContactRepoConnectionString"].ConnectionString;
        }
        
        
        
        public void Update()
        {
            try 
            {
                db.SubmitChanges();

            }
            catch(Exception) 
            {
                throw;
            }
       }

        public tbl_ContactDB GetUpdate(string AccountID)
        {
            tbl_ContactDB listContacts = new tbl_ContactDB();
            try
            {

                listContacts = (from c in db.tbl_ContactDBs
                                where c.AccountID == AccountID
                                select c).SingleOrDefault();

                if (listContacts == null) return null;
            }
            catch (Exception) { throw; }
            return listContacts;
        
        }
       public tbl_ContactDB CreateAccount(string FirstName,
            string MiddleName,
            string LastName,
            string Address,
            string City,
            string Province,
            int ZipCode,
            int TelephoneNumber,
            int MobileNumber,
            string Email) 
       {
       
            AccountConsole account = new AccountConsole();

            try
            {
                if (String.IsNullOrEmpty(FirstName)) throw new ApplicationException("First Name is Empty.");
                else if (String.IsNullOrEmpty(MiddleName)) throw new ApplicationException("Middle Name is Empty.");
                else if (String.IsNullOrEmpty(LastName)) throw new ApplicationException("Last Name is Empty.");
                else if (String.IsNullOrEmpty(Address)) throw new ApplicationException("Address is Empty.");
                else if (String.IsNullOrEmpty(MobileNumber.ToString())) throw new ApplicationException("Mobile Number is Empty.");
                else if (String.IsNullOrEmpty(Email)) throw new ApplicationException("Email Address is Empty.");
                else if (AccountEmailExists(Email)) throw new ApplicationException("Email Address Already Exist.");
                else if (MobileExist(MobileNumber)) throw new ApplicationException("Mobile Number Already Exist.");
                else if (NameExist(FirstName, MiddleName, LastName)) throw new ApplicationException("Name Already Exist.");
                else 
                {
                    tbl_ContactDB consoles = new tbl_ContactDB();
                    
                    consoles.AccountID=(String.Format("{0:000}",generateID()));
                    consoles.FirstName = FirstName;
                    consoles.MiddleName = MiddleName;
                    consoles.LastName = LastName;
                    consoles.Address = Address;
                    consoles.City = City;
                    consoles.Province = Province;
                    consoles.ZipCode = ZipCode;
                    consoles.TelephoneNumber = TelephoneNumber;
                    consoles.MobileNumber = MobileNumber;
                    consoles.Email = Email;
                    consoles.TimeSubmitted = DateTime.Now;
                    db.tbl_ContactDBs.InsertOnSubmit(consoles);
                    Update();
                    return consoles;
                }
       
               
       
            }
            catch (Exception) 
            {

                throw;
            }

            
       
       }

       public tbl_ContactDB UpdateAccount(string AccountID,
           string FirstName,
           string MiddleName,
           string LastName,
           string Address,
           string City,
           string Province,
           int ZipCode,
           int TelephoneNumber,
           int MobileNumber,
           string Email)
       {

           tbl_ContactDB account = new tbl_ContactDB();

           try
           {
               account = db.tbl_ContactDBs.FirstOrDefault(a => a.AccountID.Equals(AccountID));
               if (account != null) 
               {
                   account.FirstName = FirstName;
                   account.MiddleName = MiddleName;
                   account.LastName=LastName;
                   account.Address=Address;
                   account.City=City;
                   account.Province=Province;
                   account.ZipCode=(int)ZipCode;
                   account.TelephoneNumber=(int)TelephoneNumber;
                   account.MobileNumber = (int)MobileNumber;
                   account.Email = Email;
                   Update();
               }
               else
                   throw new ApplicationException("I can't Find the AccountID.");
           }
           catch { }
           return account;

       }

       public tbl_ContactDB DeleteAccount(string AccountID)
       {
           tbl_ContactDB account = new tbl_ContactDB();
           try
           {
               account = db.tbl_ContactDBs.FirstOrDefault(c => c.AccountID.Equals(AccountID));
               if (account != null)
               {
                   db.tbl_ContactDBs.DeleteOnSubmit(account);
                   Update();
               }
               else
                   return null;
           }
           catch { }
           return account;
           
       }

      
       public List<tbl_ContactDB> GetContacts()
       {
           List<tbl_ContactDB> listContacts = new List<tbl_ContactDB>();
           try
           {

                 listContacts = (from c in db.tbl_ContactDBs
                                   orderby c.AccountID ascending
                                   select c).ToList();

                   
           }
           catch (Exception) { throw; }
           return listContacts;
       }

       public int generateID() 
       {
           int id=0;
           try
           {
               tbl_ContactDB account_in_db = (from c in db.tbl_ContactDBs
                                   orderby c.AccountID descending
                                   select c).First();

               if (account_in_db != null) id = int.Parse(account_in_db.AccountID);
               else id = 0;
                                   

           }
           catch { }
           return id=id + 1;
       } 

       public bool MobileExist(int MobileNumber)
       {
           bool flag = false;
           try
           {
               tbl_ContactDB account = db.tbl_ContactDBs.FirstOrDefault(a => a.MobileNumber == MobileNumber );
               if (account != null) { flag = true; }

           }
           catch { }
           return flag;

       }

       public bool AccountEmailExists(string Email)
       {
           bool flag = false;
           try
           {
               tbl_ContactDB account_in_db = db.tbl_ContactDBs.FirstOrDefault(a => a.Email.ToLower().Equals(Email.ToLower()));
               if (account_in_db != null)
               {
                   flag = true;
               }
           }
           catch { }

           return flag;
       }

       public bool NameExist(string FirstName,string MiddleName,string LastName)
       {
           bool flag = false;
           try
           {
               tbl_ContactDB account_in_db = (from c in db.tbl_ContactDBs
                                            where c.FirstName.ToLower() == FirstName.ToLower() &&
                                            c.MiddleName.ToLower() == MiddleName.ToLower() &&
                                            c.LastName.ToLower() == LastName.ToLower()
                                            select c).FirstOrDefault();

               if (account_in_db != null)
               {
                   flag = true;
               }
           }
           catch { }

           return flag;
       }

    
    }

        
 }
