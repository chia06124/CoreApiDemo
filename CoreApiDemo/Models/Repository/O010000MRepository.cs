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
                             TaxResidencyData = (from d in _EFDATAContext.TaxResidencies
                                                 where a.FormID == d.FormID && a.FormNo == d.FormNo
                                                 select new TaxResidency
                                                 {
                                                     FormID = d.FormID,
                                                     FormNo = d.FormNo,
                                                     NationCode = d.NationCode,
                                                     NationName = d.NationName,
                                                     TaxID = d.TaxID,
                                                     ReasonID = d.ReasonID,
                                                     ReasonDesc = d.ReasonDesc,
                                                     CreateUser = d.CreateUser,
                                                     CreateDate = d.CreateDate
                                                 }).ToList()
                         };
            return (IEnumerable<TEntity>)result;
        }

        public Object SetData(EFDATAContext _EFDATAContext, TEntity data)
        {
            
            O010000M objO010000M = new O010000M();
            O010000MDTO? dataValue = data as O010000MDTO; //賦予物件
            objO010000M.FormID = dataValue.FormID;
            objO010000M.FormNo = dataValue.FormNo;
            objO010000M.CreateUser = "Lily1101";
            objO010000M.CreateDate = DateTime.Now;
            _EFDATAContext.O010000Ms.Add(objO010000M).CurrentValues.SetValues(dataValue);
            _EFDATAContext.SaveChanges();

            CusBaseDatum objCusBaseDatum = new CusBaseDatum();
            objCusBaseDatum.FormID = objO010000M.FormID;
            objCusBaseDatum.FormNo = objO010000M.FormNo;
            objCusBaseDatum.CreateUser = "Lily1101";
            objCusBaseDatum.CreateDate = DateTime.Now;
            _EFDATAContext.Add(objCusBaseDatum).CurrentValues.SetValues(dataValue);
            _EFDATAContext.SaveChanges();

            foreach (var objTaxResidency in dataValue.TaxResidencyData)
            {
                TaxResidency oTaxResidency = new TaxResidency();
                objTaxResidency.FormID = dataValue.FormID;
                objTaxResidency.FormNo = dataValue.FormNo;
                objTaxResidency.CreateUser = "Lily1101";
                objTaxResidency.CreateDate = DateTime.Now.AddDays(2);
                _EFDATAContext.TaxResidencies.Add(oTaxResidency).CurrentValues.SetValues(objTaxResidency);
                _EFDATAContext.SaveChanges();

            }

            return dataValue;
        }
        
    }
}
