using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.BugFixes
{
    public class BugFixChangeDate
    {
        public int Id { get; set; }
        public string BugFixesId { get; set; }
        public string UserId { get; set; }
        public DateTime OldFromDate { get; set; }
        public DateTime OldToDate { get; set; }
        public int OldDuration { get; set; }
        public DateTime NewFromDate { get; set; }
        public DateTime NewToDate { get; set; }
        public int NewDuration { get; set; }
        public string Reason { get; set; }

        public BugFixChangeDate()
        {
            OldFromDate = new DateTime();
            OldToDate = new DateTime();
            NewFromDate = new DateTime();
            NewToDate = new DateTime();
        }
    }
}
