using CoreApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiDemo.DTO.Info
{
    public class SetApplyDadaParameter
    {
        public string FormID { get; set; } = null!;
        public string FormNo { get; set; } = null!;
        public string CustType { get; set; } = null!;
        public string Com { get; set; } = null!;
        public string ComName { get; set; } = null!;
        public string DealAddr { get; set; } = null!;
        public string DealDate { get; set; } = null!;
        public string DealUserId { get; set; } = null!;
        public string OpenSales { get; set; } = null!;
        public string OpenSalesName { get; set; } = null!;
        public string CustIdno { get; set; } = null!;
        public string? CustTaxId { get; set; } = null!;
        public string CustName { get; set; } = null!;
        public string CustEngName { get; set; } = null!;
        public string Birthday { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Nationality { get; set; } = null!;
        public string BirthCountry { get; set; } = null!;
        public string? BirthCity { get; set; } = null!;
        public string Edu { get; set; } = null!;
        public string JobOcc { get; set; } = null!;
        public string JobOccDesc { get; set; } = null!;
        public string Company { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string RegZip { get; set; } = null!;
        public string RegAddr { get; set; } = null!;

        public string ComZip { get; set; } = null!;
        public string ComAddr { get; set; } = null!;
        public string ResiAddr { get; set; } = null!;
        public string Mphone { get; set; } = null!;
        public string RegTelArea { get; set; } = null!;
        public string RegTelNumber { get; set; } = null!;
        public string? ComTelArea { get; set; } = null!;
        public string ComTelNumber { get; set; } = null!;
        public string CompTelArea { get; set; } = null!;
        public string CompTelNumber { get; set; } = null!;
        public string CompTelExt { get; set; } = null!;
        public string? FaxArea { get; set; } = null!;
        public string? FaxNumber { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string DocWay { get; set; } = null!;
        public string CustClass { get; set; } = null!;

        ////////////////////////
        public List<TaxResidency> TaxResidencyData { get; set; } = null!;
        //public Object RelationData { get; set; } = null!;
        //public Object CreditData { get; set; } = null!;
        //public Object SMSData { get; set; } = null!;
        //public Object FUTData { get; set; } = null!;
        //public Object SBKData { get; set; } = null!;
        //public Object NRLData { get; set; } = null!;
        //public Object TxBankData { get; set; } = null!;
        //public Object SignDocData { get; set; } = null!;

    }
}
