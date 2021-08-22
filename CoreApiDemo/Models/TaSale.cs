using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class TaSale
    {
        public int Com { get; set; }
        public int Dept { get; set; }
        public int Sales { get; set; }
        public string SalesName { get; set; }
        public int EmpNo { get; set; }
        public string PhoneExt { get; set; }
        public string MobileNo1 { get; set; }
        public string MobileNo2 { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string Memo { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
