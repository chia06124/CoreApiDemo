using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class TaxResidency
    {
        public int Serial { get; set; }
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public string NationCode { get; set; }
        public string NationName { get; set; }
        public string TaxId { get; set; }
        public string ReasonId { get; set; }
        public string ReasonDesc { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
