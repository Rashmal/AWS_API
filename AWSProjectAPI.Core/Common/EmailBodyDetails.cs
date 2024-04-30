using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Common
{
    public class EmailBodyDetails
    {
        public List<EmailAddress> ToAddressList { get; set; }

        public List<EmailAddress> CCAddressList { get; set; }

        public List<EmailAddress> BCCAddressList { get; set; }

        public EmailAddress FromAddress { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public List<string> AttachmentPath { get; set; }

        //Constructor
        public EmailBodyDetails()
        {
            this.ToAddressList = new List<EmailAddress>();
            this.FromAddress = new EmailAddress();
            this.AttachmentPath = new List<string>();
        }
    }
}
