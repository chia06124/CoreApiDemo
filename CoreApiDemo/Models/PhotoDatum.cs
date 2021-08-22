using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class PhotoDatum
    {
        public int Serial { get; set; }
        public string FormId { get; set; }
        public string FormNo { get; set; }
        public int Ptype { get; set; }
        public int Stype { get; set; }
        public int RoleCode { get; set; }
        public int RoleCodeSerial { get; set; }
        public string Binary { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
