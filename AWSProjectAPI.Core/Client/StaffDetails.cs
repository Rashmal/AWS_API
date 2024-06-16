using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class StaffDetails
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<int> UserRoleList { get; set; }
        public string AccountId { get; set; }
        public BusinessAddress BusinessAddress { get; set; }



        public StaffDetails()
        {
            UserRoleList = new List<int>();
            DateOfBirth = DateTime.Now;
            BusinessAddress = new BusinessAddress();
        }
    }
}
