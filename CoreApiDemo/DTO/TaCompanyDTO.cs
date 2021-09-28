using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.DTO
{
    public class TaCompanyDTO
    {
        public int Com { get; set; }
        public string Cosy { get; set; } = null!;
        public string ComName { get; set; } = null!;
        public int Status { get; set; }
        public string Address { get; set; } = null!;
        public string PhoneNo { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUerName { get; set; } = null!;
    }
}
