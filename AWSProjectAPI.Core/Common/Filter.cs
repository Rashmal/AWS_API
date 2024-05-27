using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSProjectAPI.Core.Common
{
    public class Filter
    {
        public string SearchQuery { get; set; }
        public int RecordsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public string StaffId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int ModuleId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int ParentId { get; set; }
        public string Id { get; set; }
        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public string? Param1 { get; set; }

        public Filter()
        {
            SearchQuery = "";
            RecordsPerPage = 10;
            CurrentPage = 0;
            StaffId = "";
            StatusId = 0;
            PriorityId = 0;
            ModuleId = 0;
            //StartDate = DateTime.Now;
            //EndDate = DateTime.Now;
        }
    }
}
