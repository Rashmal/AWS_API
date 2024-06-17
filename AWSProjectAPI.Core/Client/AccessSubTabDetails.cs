using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class AccessSubTabDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool EnableAccess { get; set; }
        public List<AccessFeatureDetails> AccessLevelFeatureDetailsList { get; set; }
        public int DefaultColRef { get; set; }
        public string SubTabCode { get; set; }

        public AccessSubTabDetails()
        {
            AccessLevelFeatureDetailsList = new List<AccessFeatureDetails>();
        }
    }
}
