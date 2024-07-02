using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ContactDetails> ContactDetails { get; set; }
       
        public int TotalRecords { get; set; }

        public Contact()
        {
            ContactDetails = new List<ContactDetails>();
        }
    }

    public class ContactDetails {
        public int Id { get; set; }
        public string ContactValue { get; set; }
        public ContactType ContactType { get; set; }
    }
}
