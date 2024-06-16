using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class DisplayStaffDetails
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string PrimaryUserRole { get; set; }
        public List<UserRole> UserRoleList { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; }
        public int Total { get; set; }

        public DisplayStaffDetails()
        {
            UserRoleList = new List<UserRole>();
            CreatedDate = DateTime.Now;
            DateOfBirth = DateTime.Now;
        }
    }
}
