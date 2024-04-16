using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Common
{
    public class Status
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string ColorCode { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Status otherStatus = (Status)obj;
            return Id == otherStatus.Id && Name == otherStatus.Name && Code == otherStatus.Code && ColorCode == otherStatus.ColorCode;
        }
    }
}
