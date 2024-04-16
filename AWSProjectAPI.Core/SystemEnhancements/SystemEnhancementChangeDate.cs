using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.SystemEnhancements
{
    public class SystemEnhancementChangeDate
    {
        public int Id { get; set; }
        public string SystemEnhancementId { get; set; }
        public string UserId { get; set; }
        public DateTime OldFromDate { get; set; }
        public DateTime OldToDate { get; set; }
        public int OldDuration { get; set; }
        public DateTime NewFromDate { get; set; }
        public DateTime NewToDate { get; set; }
        public int NewDuration { get; set; }
        public string Reason { get; set; }

        public SystemEnhancementChangeDate()
        {
            OldFromDate = new DateTime();
            OldToDate = new DateTime();
            NewFromDate = new DateTime();
            NewToDate = new DateTime();
        }
    }
}
