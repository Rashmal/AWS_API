using AWSProjectAPI.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class SocialMedia
    {
        public int Id { get; set; }
        public string Setting { get; set; }
        public SocialMediaType SocialMediaType { get; set; }

        public SocialMedia()
        {
            SocialMediaType = new SocialMediaType();
        }
    }
}
