using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class SubTabDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool EnableAccess { get; set; }
        public List<AccessLevelFeatureDetails> AccessLevelFeatureDetailsList { get; set; }
        public int Total { get; set; }

        public SubTabDetails()
        {
            AccessLevelFeatureDetailsList = new List<AccessLevelFeatureDetails>();
        }

    }
}
