using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class AccessFeatureDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool AddAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool DeleteAccess { get; set; }
    }
}
