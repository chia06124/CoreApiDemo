using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class TaCompany
    {
        public int Com { get; set; }
        public string Cosy { get; set; }
        public string ComName { get; set; }
        public int Status { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Fax { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int UpdateUerId { get; set; }
        public TaSale TaSale01 { get; set; } //反向導覽屬性
    }
}
