using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class ClientCustomer
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string BusinessNumber { get; set; }
        public BusinessNumberType BusinessNumberType { get; set; }

        public ClientCustomer()
        {
            BusinessNumberType = new BusinessNumberType();
        }
    }
}
