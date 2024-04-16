using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.BugFixes
{
    public class ViewBugFixChangeDate
    {
        public DateTime NewFromDate { get; set; }
        public DateTime NewToDate { get; set; }
        public int NewDuration { get; set; }
        public string Reason { get; set; }
        public DateTime ChangedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Total { get; set; }

        public ViewBugFixChangeDate()
        {
            NewFromDate = new DateTime();
            NewToDate = new DateTime();
            ChangedDate = new DateTime();
        }
    }
}
