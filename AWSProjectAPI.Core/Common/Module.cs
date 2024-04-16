using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Common
{
    public class Module
    {
        public int Id { get; set; }
        public string ModuleCode { get; set; }
        public string Name { get; set; }
        public string ModuleIcon { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsDisable { get; set; }
    }
}
