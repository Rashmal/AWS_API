using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.SystemEnhancements
{
    public class SystemEnhancementComment
    {
        public int Id { get; set; }
        public string SystemEnhancementId { get; set; }
        public string UserId { get; set; }
        public int ParentId { get; set; }
        public string Description { get; set; }
    }
}
