using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Common
{
    public class Priority
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Priority otherPriority = (Priority)obj;
            return Id == otherPriority.Id && Name == otherPriority.Name && Code == otherPriority.Code;
        }
    }
}
