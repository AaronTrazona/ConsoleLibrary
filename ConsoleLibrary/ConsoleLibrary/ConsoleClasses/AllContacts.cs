using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ConsoleLibrary.ConsoleClasses
{
    [DataContract] 
    public class AllContacts
    {
         [DataMember]
         public List<AccountConsole> Contacts;

    }
}
