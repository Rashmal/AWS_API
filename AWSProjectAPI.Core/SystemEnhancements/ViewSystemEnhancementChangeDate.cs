using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.SystemEnhancements
{
    public class ViewSystemEnhancementChangeDate
    {
        public int Id { get; set; }
        public DateTime NewFromDate { get; set; }
        public DateTime NewToDate { get; set; }
        public int NewDuration { get; set; }
        public string Reason { get; set; }
        public DateTime ChangedDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Total { get; set; }
        public int ApproveState { get; set; }

        public ViewSystemEnhancementChangeDate()
        {
            NewFromDate = new DateTime();
            NewToDate = new DateTime();
            ChangedDate = new DateTime();
        }

    }
}
