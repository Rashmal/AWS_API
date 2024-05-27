using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class RelationshipDetails
    {
        public int Id { get; set; }
        public string OfficeJob { get; set; }
        public double WorkCredit { get; set; }
        public int ClientTerms { get; set; }
        public double DefaultDeposit { get; set; }
        public int MonthDayAlert { get; set; }
        public string FinancialNotes { get; set; }
        public int SupplierTerms { get; set; }
        public bool IsSupplier { get; set; }
        public bool IsSubcontractor { get; set; }
        public bool IsClient { get; set; }
        public bool IsAutoProgressReport { get; set; }
        public DateTime NextReportDateTime { get; set; }
        public PriceClassification PriceClassification { get; set; }
        public ClientSize ClientSize { get; set; }
        public TermType ClientTermType { get; set; }
        public TermType SupplierTermType { get; set; }
        public DayDetails DayDetails { get; set; }
        public RatingDetails RatingDetails { get; set; }
        public AccountDetails ExpenseAccount { get; set; }

        public RelationshipDetails()
        {
            NextReportDateTime = new DateTime();
            PriceClassification = new PriceClassification();
            ClientSize = new ClientSize();
            ClientTermType = new TermType();
            SupplierTermType = new TermType();
            DayDetails = new DayDetails();
            RatingDetails = new RatingDetails();
            ExpenseAccount = new AccountDetails();
        }
    }
}
