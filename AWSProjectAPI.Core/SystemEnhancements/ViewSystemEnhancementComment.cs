using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.SystemEnhancements
{
    public class ViewSystemEnhancementComment
    {
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public int Total { get; set; }
        public bool HasReply { get; set; }

        public ViewSystemEnhancementComment()
        {
            AddedDate = new DateTime();
        }

    }
}
