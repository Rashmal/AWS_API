using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class HourlyOtherRates
    {
        public int Id { get; set; }
        public string RateName { get; set; }
        public double Rate { get; set; }
        public string RateType { get; set; }
        public int TotalRecords { get; set; }
    }
}
