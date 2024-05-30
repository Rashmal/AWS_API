using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class GlobalFileDetails
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public int TotalRecords { get; set; }
        public string LocalPath { get; set; }
    }
}
