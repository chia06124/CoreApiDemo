using System;
using System.Collections.Generic;

#nullable disable

namespace CoreApiDemo.Models
{
    public partial class CusBaseDatum
    {
        public string FormID { get; set; }
        public string FormNo { get; set; }
        public string CustIdno { get; set; }
        public string CustTaxId { get; set; }
        public string CustName { get; set; }
        public string CustEngName { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string BirthCountry { get; set; }
        public string BirthCity { get; set; }
        public string Edu { get; set; }
        public string JobOcc { get; set; }
        public string JobOccDesc { get; set; }
        public string Company { get; set; }
        public string Position { get; set; }
        public string RegZip { get; set; }
        public string RegAddr { get; set; }
        public string ComZip { get; set; }
        public string ComAddr { get; set; }
        public string ResiAddr { get; set; }
        public string Mphone { get; set; }
        public string RegTelArea { get; set; }
        public string RegTelNumber { get; set; }
        public string ComTelArea { get; set; }
        public string ComTelNumber { get; set; }
        public string CompTelArea { get; set; }
        public string CompTelNumber { get; set; }
        public string CompTelExt { get; set; }
        public string FaxArea { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string DocWay { get; set; }
        public string CustClass { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
