using CoreApiDemo.DTO;
using CoreApiDemo.DTO.Info;
using CoreApiDemo.Models.Interface;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreApiDemo.Models.Repository
{
    public class O010000MRepository<TEntity> : IRepositoryObject<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> GetAll(EFDATAContext _EFDATAContext, JsonElement data)
        {
            var result = from a in _EFDATAContext.O010000Ms
                         join c in _EFDATAContext.CusBaseData on new { a.FormID, a.FormNo } equals new { c.FormID, c.FormNo }
                         where a.Com == data.GetProperty("comp_code").GetString() && c.CustIdno == data.GetProperty("customer_id").GetString()
                         select new O010000MDTO
                         {
                             FormID = a.FormID,
                             FormNo = a.FormNo,
                             CustType = a.CustType,
                             Com = a.Com,
                             ComName = a.ComName,
                             DealAddr = a.DealAddr,
                             OpenSales = a.OpenSales,
                             OpenSalesName = a.OpenSalesName,
                             CustTaxID = c.CustIdno,
                             CustName = c.CustName,
                             Birthday = c.Birthday,
                             Gender = c.Gender,
                             Nationality = c.Nationality,
                             BirthCountry = c.BirthCountry,
                             BirthCity = c.BirthCity,
                             Edu = c.Edu,
                             JobOccDesc = c.JobOccDesc,
                             Company = c.Company,
                             Position = c.Position,
                             RegZip = c.RegZip,
                             RegAddr = c.RegAddr,
                             ComZip = c.ComZip,
                             ComAddr = c.ComAddr,
                             ResiAddr = c.ResiAddr,
                             MPhone = c.Mphone,
                             RegTelArea = c.RegTelArea,
                             RegTelNumber = c.RegTelNumber,
                             ComTelArea = c.ComTelArea,
                             ComTelNumber = c.ComTelNumber,
                             CompTelExt = c.CompTelExt,
                             FaxArea = c.FaxArea,
                             FaxNumber = c.FaxNumber,
                             EMail = c.Email,
                             FutdatumData = (from d in _EFDATAContext.Futdata
                                             where a.FormID == d.FormId && a.FormNo == d.FormNo
                                             select new Futdatum
                                             {
                                                 FormId = d.FormId,
                                                 FormNo = d.FormNo,
                                                 EtradingFlag = d.EtradingFlag,
                                                 SettlementWay = d.SettlementWay,
                                                 MarginCallTrading = d.MarginCallTrading,
                                                 MarketPrice = d.MarketPrice,
                                                 MarginEway = d.MarginEway,
                                                 SignDocVer = d.SignDocVer,
                                                 CreateUser = d.CreateUser,
                                                 CreateDate = d.CreateDate,
                                                 HonStockFlag = d.HonStockFlag,
                                                 HonTradingFlag = d.HonTradingFlag
                                             }).ToList()
                         };
            return (IEnumerable<TEntity>)result;
        }
    }
}
