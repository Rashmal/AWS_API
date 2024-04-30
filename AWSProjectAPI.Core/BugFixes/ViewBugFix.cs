using AWSProjectAPI.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.BugFixes
{
    public class ViewBugFix
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string StatusName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EstimatedHours { get; set; }
        public string PriorityName { get; set; }
        public List<BasicUserDetails> RequestedStaffList { get; set; }
        public int Total { get; set; }
        public int HasRequest { get; set; }
        public bool IsNew { get; set; }

        public ViewBugFix()
        {
            StartDate = new DateTime();
            EndDate = new DateTime();
            RequestedStaffList = new List<BasicUserDetails>();
        }
    }
}
