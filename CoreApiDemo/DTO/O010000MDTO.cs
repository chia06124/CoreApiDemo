using CoreApiDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.DTO
{
    public class O010000MDTO
    {
        //= null!;可為null
        public string? FormID { get; set; } 
        public string? FormNo { get; set; }
        //public object EnableOpenType { get; set; } = null!;
        //public object OpenType { get; set; } = null!;
        public string? CustType { get; set; }
        public string? Com { get; set; }
        public string? ComName { get; set; } 
        public string? DealAddr { get; set; } 
        public string? OpenSales { get; set; }
        public string? OpenSalesName { get; set; }
        public string? CustIDNo { get; set; }
        public string? CustTaxID { get; set; }
        public string? CustName { get; set; }
        public string? Birthday { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? BirthCountry { get; set; }
        public string? BirthCity { get; set; }
        public string? Edu { get; set; }
        //public string EduDesc { get; set; } = null!;
        public int? JobOcc { get; set; }
        public string? JobOccDesc { get; set; } 
        public string? Company { get; set; }
        public string? Position { get; set; }
        public string? RegZip { get; set; }
        public string? RegAddr { get; set; } 
        public string? ComZip { get; set; } 
        public string? ComAddr { get; set; }
        public string? ResiAddr { get; set; }
        public string? MPhone { get; set; } 
        public string? RegTelArea { get; set; }
        public string? RegTelNumber { get; set; }
        public string? ComTelArea { get; set; }
        public string? ComTelNumber { get; set; }
        public string? CompTelArea { get; set; }
        public string? CompTelNumber { get; set; }
        public string? CompTelExt { get; set; }
        public string? FaxArea { get; set; }
        public string? FaxNumber { get; set; }
        public string? EMail { get; set; }
        public List<Futdatum>? FutdatumData { get; set; }

    }
}
