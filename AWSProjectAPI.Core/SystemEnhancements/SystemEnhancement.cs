using AWSProjectAPI.Core.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.SystemEnhancements
{
    public class SystemEnhancement
    {
        public string Id { get; set; }
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public int ModuleId { get; set; }
        public string AddedUserId { get; set; }
        public int EstimatedHours { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<BasicUserDetails> AssignedStaffList { get; set; }
        public List<BasicUserDetails> RequestedStaffList { get; set; }
        public int HasRequest { get; set; }

        public SystemEnhancement()
        {
            StartDate = new DateTime();
            EndDate = new DateTime();
            AssignedStaffList = new List<BasicUserDetails>();
            RequestedStaffList = new List<BasicUserDetails>();
        }
    }
}
