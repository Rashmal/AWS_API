using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class DisplayClientDetails
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string FullName { get; set; }
        public string PaymentTerm { get; set; }
        public string BillingAddress { get; set; }
        public string FinancialNotes { get; set; }
        public string ExpenseAccount { get; set; }
        public List<Contact> Contacts { get; set; }
        public int TotalRecords { get; set; }

        public DisplayClientDetails()
        {
            CreatedDate = DateTime.Now;
            Contacts = new List<Contact>();
        }
    }
}
