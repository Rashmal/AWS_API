using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class ClientRequirement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AdditionalData { get; set; }
        public RoleDetails RoleDetails { get; set; }
        public List<ClientRequirementFile> ClientRequirementFiles { get; set; }
        public int TotalRecords { get; set; }

        public ClientRequirement()
        {
            RoleDetails = new RoleDetails();
            ClientRequirementFiles = new List<ClientRequirementFile>(); 
        }
    }
}
