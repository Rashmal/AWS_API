using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Client
{
    public class ImageFiles
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string ResourceFile { get; set; }
        public string InternalNotes { get; set; }
        public ResourceType ResourceType { get; set; }
        public int TotalRecords { get; set; }
        public string CreatedByFullName { get; set; }
        public int RotateXY { get; set; }

        public ImageFiles()
        {
            ResourceType = new ResourceType();
        }
    }
}
