using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.BugFixes
{
    public class ViewBugFixComment
    {
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public int Total { get; set; }
        public bool HasReply { get; set; }

        public ViewBugFixComment()
        {
            AddedDate = new DateTime();
        }
    }
}
