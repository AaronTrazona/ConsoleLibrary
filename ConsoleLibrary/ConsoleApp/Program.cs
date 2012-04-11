using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp.ConsoleAppReference;
using ConsoleApp.Implementation;
using ConsoleApp.ConsoleClasses;
using System.ServiceModel;



using ConsoleLibrary.Implementation;
namespace ConsoleApp
{
    class Program
    {
        private ConsoleClient client = new ConsoleClient("WSHttpBinding_IConsole");
        public string temp;
        public string Display()
        {
            Console.WriteLine("\n\n\n");
            Console.WriteLine(string.Format("{0,50}", "Contact Information"));
            Console.WriteLine(string.Format("\n\n{0,40}", "[C] Create Account"));
            Console.WriteLine(string.Format("\n{0,40}", "[U] Update Account"));
            Console.WriteLine(string.Format("\n{0,40}", "[D] Delete Account"));
            Console.WriteLine(string.Format("\n{0,42}", "[V] View All Account"));
            Console.WriteLine(string.Format("\n{0,30}", "[X] Exit"));
            Console.Write(string.Format("\n\n{0,40}", "Select an Option: "));
            string select = Console.ReadLine();

            return select.ToLower();
        }

        public AllAccount GetAllData() 
        {
            FunctionClasses account = new FunctionClasses();
            return account.GetAllContact();
  
        }

        public AllAccount GetUpdate(string s)
        {
            FunctionClasses account = new FunctionClasses();
            Contact accounts = new Contact();
            Console.Write(s);
            accounts.AccountID = Console.ReadLine();
            temp = accounts.AccountID;
            return account.GetUpdate(accounts.AccountID);

        }

        public AccountConsole DeleteAccount()
        {

            try
            {
                Contact accounts = new Contact();
                Console.Write("\tAre You Sure You Want to Delete this Contact. [Y/N]?");
                if (char.Parse(Console.ReadLine().ToLower()) == 'y')
                    return client.DeleteAccount(temp);
                else
                    return null;
            }
            catch (Exception)
            {
                
                return null;
            }   
        }
        public AccountConsole CreateAccount()
        {

            bool parsing;
            Contact account = new Contact();
            
            
            Console.Write("\t\tFirstName      : ");
            account.FirstName = Console.ReadLine();
            Console.Write("\t\tMiddleName     : ");
            account.MiddleName = Console.ReadLine();
            Console.Write("\t\tLastName       : ");
            account.LastName = Console.ReadLine();
            Console.Write("\t\tAddress        : ");
            account.Address = Console.ReadLine();
            Console.Write("\t\tCity           : ");
            account.City = Console.ReadLine();
            Console.Write("\t\tProvince       : ");
            account.Province = Console.ReadLine();
            Console.Write("\t\tZipCode        : ");
            parsing = int.TryParse(Console.ReadLine(),out account.ZipCode);
            if (!parsing) account.ZipCode = 0;
            Console.Write("\t\tTelephoneNumber: ");
            parsing = int.TryParse(Console.ReadLine(),out account.TelephoneNumber);
            if (!parsing) account.TelephoneNumber=0;
            Console.Write("\t\tMobileNumber   : ");
            parsing = int.TryParse(Console.ReadLine(),out account.MobileNumber);
            if (!parsing) return null;
            Console.Write("\t\tEmail          : ");
            account.Email = Console.ReadLine();

            return client.CreateAccount(account.FirstName, account.MiddleName, account.LastName, account.Address, account.City, account.Province, account.ZipCode, account.TelephoneNumber, account.MobileNumber, account.Email);
        }

        public AccountConsole UpdateAccount()
        {

            bool parsing;

            
            Contact account = new Contact();

              
                Console.Write("\t\tFirstName      : ");
                account.FirstName = Console.ReadLine();
                Console.Write("\t\tMiddleName     : ");
                account.MiddleName = Console.ReadLine();
                Console.Write("\t\tLastName       : ");
                account.LastName = Console.ReadLine();
                Console.Write("\t\tAddress        : ");
                account.Address = Console.ReadLine();
                Console.Write("\t\tCity           : ");
                account.City = Console.ReadLine();
                Console.Write("\t\tProvince       : ");
                account.Province = Console.ReadLine();
                Console.Write("\t\tZipCode        : ");
                parsing = int.TryParse(Console.ReadLine(), out account.ZipCode);
                if (!parsing) account.ZipCode = 0;
                Console.Write("\t\tTelephoneNumber: ");
                parsing = int.TryParse(Console.ReadLine(), out account.TelephoneNumber);
                if (!parsing) account.TelephoneNumber = 0;
                Console.Write("\t\tMobileNumber   : ");
                parsing = int.TryParse(Console.ReadLine(), out account.MobileNumber);
                if (!parsing) return null;
                Console.Write("\t\tEmail          : ");
                account.Email = Console.ReadLine();

                return client.UpdateAccount(temp, account.FirstName, account.MiddleName, account.LastName, account.Address, account.City, account.Province, account.ZipCode, account.TelephoneNumber, account.MobileNumber, account.Email);
           
        }


       

        static void Main(string[] args)
        {
            bool flag=true;
            char select;
            
           
            Program function = new Program();
            FunctionClasses imp = new FunctionClasses();
            
            do
            {
                
                bool option = char.TryParse(function.Display(), out select);

                if (option)
                {

                    switch (select)
                    {
                        case 'c':
                            Console.Clear();
                            Console.WriteLine("\n\n\t\t\t\tCreate Contact\n\n");                           
                            if (function.CreateAccount()==null)
                            Console.Write("\n\t\t\tError in Creating Contact");
                            Console.Write("\n\t\t\tPress <Enter> to Continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 'u':
                            Console.Clear();

                            Console.WriteLine("\n\n\t\t\t\tUpdate Contact\n\n");
                            if (function.GetUpdate("\t\tEnter the AccountID to be Update: ") == null)
                                 Console.Write("\n\t\t\tI Can't Find AccountID");
                            else if(function.UpdateAccount() ==null)
                                Console.Write("\n\t\t\tError in Updating Contact");
                            Console.Write("\n\t\t\tPress <Enter> to Continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 'd':
                            Console.Clear();
                            Console.WriteLine("\n\n\t\t\t\tDelete Contact\n\n");
                            if (function.GetUpdate("\t\tEnter the AccountID to be Delete: ") == null)
                                 Console.Write("\n\t\t\tI Can't Find AccountID");
                            else if(function.DeleteAccount() ==null)
                                Console.Write("\n\t\t\tError in Delete Contact");
                            else
                                Console.Write("\n\t\t\tSuccessfully Deleted.");
                            Console.Write("\n\t\t\tPress <Enter> to Continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 'v':
                            Console.Clear();
                            Console.WriteLine("\n\n\t\t\tAll Contact Information\n\n");
                            if(function.GetAllData()==null)
                            Console.Write("\n\t\t\tNo Contact");
                            Console.Write("\n\t\t\tPress <Enter> to Continue");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 'x':
                            flag = false;
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine(string.Format("\n{0,40}", "Incorrect Option."));

                            break;
                    }

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(string.Format("\n{0,40}", "Invalid."));
                }    
            }while(flag); 
        }
       
    }
}
