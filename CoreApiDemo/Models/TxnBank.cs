using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class TxnBank
    {
        public int Serial { get; set; }
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public string Type { get; set; }
        public string Currency { get; set; }
        public int DepositWithdraw { get; set; }
        public string BankBranchCode { get; set; }
        public string Account { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
