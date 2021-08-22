using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class SysCodeMap
    {
        public string ClassCode { get; set; }
        public string ClassName { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int Seq { get; set; }
        public string Memo { get; set; }
        public string Sdate { get; set; }
        public string Edate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
