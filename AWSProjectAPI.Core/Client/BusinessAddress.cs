using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class BusinessAddress
    {
        public int Id { get; set; }
        public string BuildingName { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public Country Country { get; set; }

        public BusinessAddress()
        {
            Country = new Country();
        }
    }
}
