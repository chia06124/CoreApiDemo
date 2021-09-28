using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.DTO
{
    public class ApplyDataDTO
    {
        //= null!;可為null
        public string FormID { get; set; } = null!;
        public string FormNo { get; set; } = null!;
        public object EnableOpenType { get; set; } = null!;
        public object OpenType { get; set; } = null!;
        public int CustType { get; set; }
        public string Com { get; set; } = null!;
        public string ComName { get; set; } = null!;
        public string DealAddr { get; set; } = null!;
        public string OpenSales { get; set; } = null!;
        public string OpenSalesName { get; set; } = null!;
        public string CustIDNo { get; set; } = null!;
        public string CustTaxID { get; set; } = null!;
        public string CustName { get; set; } = null!;
        public string Birthday { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string BirthCountry { get; set; } = null!;
        public string BirthCity { get; set; } = null!;
        public int Edu { get; set; }
        public string EduDesc { get; set; } = null!;
        public int JobOcc { get; set; }
        public string JobOccDesc { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string RegZip { get; set; } = null!;
        public string RegAddr { get; set; } = null!;
        public string ComZip { get; set; } = null!;
        public string ComAddr { get; set; } = null!;
        public string ResiAddr { get; set; } = null!;
        public string MPhone { get; set; } = null!;
        public string RegTelArea { get; set; } = null!;
        public string RegTelNumber { get; set; } = null!;
        public string ComTelArea { get; set; } = null!;
        public string ComTelNumber { get; set; } = null!;
        public string CompTelArea { get; set; } = null!;
        public string CompTelNumber { get; set; } = null!;
        public string CompTelExt { get; set; } = null!;
        public string FaxArea { get; set; } = null!;
        public string FaxNumber { get; set; } = null!;
        public string EMail { get; set; } = null!;
        public object RelationData { get; set; } = null!;

    }
}
