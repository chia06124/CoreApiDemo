using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class Smsdatum
    {
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public string SettlementWay { get; set; }
        public string EtradingFlag { get; set; }
        public string TdccbookFlag { get; set; }
        public string SignDocVer { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
