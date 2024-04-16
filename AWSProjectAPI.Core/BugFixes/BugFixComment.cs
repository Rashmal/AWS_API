using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.BugFixes
{
    public class BugFixComment
    {
        public int Id { get; set; }
        public string BugFixesId { get; set; }
        public string UserId { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
    }
}
