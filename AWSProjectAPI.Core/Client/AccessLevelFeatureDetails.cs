using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class AccessLevelFeatureDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool AddAccess { get; set; }
        public bool EditAccess { get; set; }
        public bool DeleteAccess { get; set; }
        public bool ViewAccess { get; set; }
        public string Accessible { get; set; }

    }
}
