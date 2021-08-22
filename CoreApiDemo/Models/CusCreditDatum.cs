using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class CusCreditDatum
    {
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public string Bounced { get; set; }
        public string Oa { get; set; }
        public string Oareason { get; set; }
        public string OtherBrokersAcc { get; set; }
        public string PersonalIncome { get; set; }
        public string FamilyAnnualIncome { get; set; }
        public string CompanyIncome { get; set; }
        public string Immovables { get; set; }
        public string ImmovablesVal { get; set; }
        public string Arrears { get; set; }
        public string ArrearsVal { get; set; }
        public string AvgDeposit { get; set; }
        public string OtherAssets { get; set; }
        public string OtherAssetsName { get; set; }
        public string OtherAssetsVal { get; set; }
        public string TotalVal { get; set; }
        public string TradingExp { get; set; }
        public string TradingExpFy { get; set; }
        public string TradingExpSy { get; set; }
        public string TradingExpBy { get; set; }
        public string TradingExpHy { get; set; }
        public string TradingExpOtherN { get; set; }
        public string TradingExpOtherY { get; set; }
        public string TradingTerm { get; set; }
        public string TradingFreq { get; set; }
        public string FundsSources { get; set; }
        public string FundsSourcesDsc { get; set; }
        public string ComCapital { get; set; }
        public string FundSize { get; set; }
        public string ExpectedQuota { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
