﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoreApiDemo.DTO;
using CoreApiDemo.DTO.Info;
using CoreApiDemo.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApiDemo.Controllers
{
    [Route("/api/[controller]/[action]")]
    [ApiController]
    public class OOTempController : ControllerBase
    {
        private readonly EFDATAContext _EFDATAContext;
        private readonly IMapper _mapper;
        public OOTempController(EFDATAContext EFDATAContext, IMapper mapper)
        {
            _EFDATAContext = EFDATAContext;
            _mapper = mapper;
        }

        [HttpGet("{comp_code}")] //分公司營業員查詢
        public IActionResult GetSalesData(string comp_code)
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                var result = _EFDATAContext.ViwHsoasales.Where(a => a.Com.Contains(comp_code)).Select(a => a).ToList();
                var map = _mapper.Map<IEnumerable<ViewHsoasalesDTO>>(result);
                if (map == null || map.Count() <= 0)
                {
                    throw new Exception("comp_code傳入參數異常");
                }
                actionResult = Ok(new ApiResult<object>(map));
            }
            catch (Exception e)
            {
                message = e.Message;
                actionResult = NotFound(new ApiError("5555", message));
            }
            return actionResult;
        }


        [HttpGet]
        public IActionResult GetCountryData()
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                var result = _EFDATAContext.ViwHsoabirthCountries.Where(a => DateTime.Now >= (DateTime)(object)a.Sdate && DateTime.Now <= (DateTime)(object)a.Edate).Select(a => new ViwHsoabirthCountryDTO
                {
                    NationCode = a.Memo,
                    NationName = a.ItemName,
                    Seq = a.Seq

                }).ToList();
                if (result == null || result.Count() <= 0)
                {

                    throw new Exception();
                }
                actionResult = Ok(new ApiResult<object>(result));
            }
            catch (Exception e)
            {
                message = e.Message;
                actionResult = NotFound(new ApiError("6666", message));
            }
            return actionResult;
        }

        [HttpGet]
        public IActionResult GetCityData()
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                var result = from a in _EFDATAContext.ViwHsoabirthCities
                             where DateTime.Now >= (DateTime)(object)a.Sdate && DateTime.Now <= (DateTime)(object)a.Edate
                             select new { CityName = a.ItemName, Seq = a.Seq };  //不會使用到ViwHsoabirthCityDTO
                if (result == null || result.Count() <= 0)
                {
                    throw new Exception();
                }
                actionResult = Ok(new ApiResult<object>(result));
            }
            catch (Exception e)
            {
                message = e.Message;
                actionResult = NotFound(new ApiError("7777", message));
            }
            return actionResult;
        }

        [HttpGet]
        public IActionResult GetApplyData(GetApplyDataPatameter data)
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                var result = from a in _EFDATAContext.O010000Ms
                             from c in _EFDATAContext.CusBaseData
                             where a.FormID == c.FormId && a.FormNo == c.FormNo
                             && a.Com == data.comp_code && c.CustIdno == data.customer_id
                             select new ApplyDataDTO
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
                                 EMail = c.Email
                             };
                //var result = _EFDATAContext.ViwHsoasales.Where(a => a.Com.Contains(comp_code)).Select(a => new ViewHsoasalesDTO
                //{
                //    Com = a.Com,
                //    ComName = a.ComName,
                //    Sales = a.Sales,
                //    SalesName = a.SalesName
                //}).ToList();


                //if (result == null || result.Count() <= 0)
                //{
                //    throw new Exception("comp_code傳入參數異常");
                //}
                actionResult = Ok(new ApiResult<object>(result));
            }
            catch (Exception e)
            {
                message = e.Message;
                actionResult = NotFound(new ApiError("5555", message));
            }
            return actionResult;
        }


        [HttpPost] //欄位內建函式mapping
        public IActionResult SetApplyData([FromBody] SetApplyDadaParameter data)
        {

            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                if (data.FormNo == null)
                {
                    throw new Exception("FormNo傳入參數異常");
                }

                O010000M objO010000M = new O010000M();
                objO010000M.FormID = data.FormID;
                objO010000M.FormNo = data.FormNo;
                objO010000M.CreateUser = "Lily1010";
                objO010000M.CreateDate = DateTime.Now;
                _EFDATAContext.Add(objO010000M).CurrentValues.SetValues(data);
                _EFDATAContext.SaveChanges();

                CusBaseDatum objCusBaseDatum = new CusBaseDatum();
                objCusBaseDatum.FormId = objO010000M.FormID;
                objCusBaseDatum.FormNo = objO010000M.FormNo;
                objCusBaseDatum.CreateUser = "Lily1010";
                objCusBaseDatum.CreateDate = DateTime.Now;
                _EFDATAContext.Add(objCusBaseDatum).CurrentValues.SetValues(data);
                _EFDATAContext.SaveChanges();

                foreach (var objTaxResidency in data.TaxResidencyData)
                {
                    TaxResidency oTaxResidency = new TaxResidency();
                    objTaxResidency.FormId = data.FormID;
                    objTaxResidency.FormNo = data.FormNo;
                    objTaxResidency.CreateUser = "Lily1010";
                    objTaxResidency.CreateDate = DateTime.Now.AddDays(2);
                    _EFDATAContext.TaxResidencies.Add(oTaxResidency).CurrentValues.SetValues(objTaxResidency);
                    _EFDATAContext.SaveChanges();

                }

                actionResult = Ok(new ApiResult<object>(data));

            }
            catch (Exception e)
            {
                message = e.Message;
                actionResult = NotFound(new ApiError("8888", message));
            }
            return actionResult;
        }

        [HttpPost]
        public IActionResult putApply([FromBody] O010000M data)
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                var result = (from a in _EFDATAContext.O010000Ms
                              where a.FormID == data.FormID && a.FormNo == data.FormNo
                              select a).FirstOrDefault();
                if (result != null)
                {
                    result.ComName = data.ComName;
                    result.DealAddr = data.DealAddr;
                    result.OpenSalesName = data.OpenSalesName;
                    _EFDATAContext.SaveChanges();
                }
                actionResult = Ok(new ApiResult<object>(data));
            }
            catch (Exception e)
            {
                message = e.Message;
                actionResult = NotFound(new ApiError("8888", message));
            }
            return actionResult;

        }




        [HttpPost]  //POST 欄位手動mapping
        public IActionResult SetApplyDatabak([FromBody] SetApplyDadaParameter data)
        {

            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                if (data.FormNo == null)
                {
                    throw new Exception("FormNo傳入參數異常");
                }
                O010000M objO010000M = new O010000M();
                objO010000M.FormID = data.FormID;
                objO010000M.FormNo = data.FormNo;
                objO010000M.CustType = data.CustType;
                objO010000M.Com = data.Com;
                objO010000M.ComName = data.ComName;
                objO010000M.DealAddr = data.DealAddr;
                objO010000M.DealDate = data.DealDate;
                objO010000M.DealUserId = data.DealUserId;
                objO010000M.OpenSales = data.OpenSales;
                objO010000M.OpenSalesName = data.OpenSalesName;
                objO010000M.CustIdno = data.CustIdno;
                objO010000M.CreateUser = "Lily1010";
                objO010000M.CreateDate = DateTime.Now;
                _EFDATAContext.Add(objO010000M);
                _EFDATAContext.SaveChanges();

                CusBaseDatum objCusBaseDatum = new CusBaseDatum();
                objCusBaseDatum.FormId = data.FormID;
                objCusBaseDatum.FormNo = data.FormNo;
                objCusBaseDatum.CustIdno = data.CustIdno;
                objCusBaseDatum.CustTaxId = data.CustTaxId;
                objCusBaseDatum.CustName = data.CustName;
                objCusBaseDatum.CustEngName = data.CustEngName;
                objCusBaseDatum.Birthday = data.Birthday;
                objCusBaseDatum.Gender = data.Gender;
                objCusBaseDatum.Nationality = data.Nationality;
                objCusBaseDatum.BirthCountry = data.BirthCountry;
                objCusBaseDatum.BirthCity = data.BirthCity;
                objCusBaseDatum.Edu = data.Edu;
                objCusBaseDatum.JobOcc = data.JobOcc;
                objCusBaseDatum.JobOccDesc = data.JobOccDesc;
                objCusBaseDatum.Company = data.Company;
                objCusBaseDatum.Position = data.Position;
                objCusBaseDatum.RegZip = data.RegZip;
                objCusBaseDatum.RegAddr = data.RegAddr;
                objCusBaseDatum.ComZip = data.ComZip;
                objCusBaseDatum.ComAddr = data.ComAddr;
                objCusBaseDatum.ResiAddr = data.ResiAddr;
                objCusBaseDatum.Mphone = data.Mphone;
                objCusBaseDatum.RegTelArea = data.RegTelArea;
                objCusBaseDatum.RegTelNumber = data.RegTelNumber;
                objCusBaseDatum.ComTelArea = data.CompTelArea;
                objCusBaseDatum.ComTelNumber = data.CompTelNumber;
                objCusBaseDatum.CompTelArea = data.CompTelArea;
                objCusBaseDatum.CompTelNumber = data.CompTelNumber;
                objCusBaseDatum.CompTelExt = data.CompTelExt;
                objCusBaseDatum.FaxArea = data.FaxArea;
                objCusBaseDatum.FaxNumber = data.FaxNumber;
                objCusBaseDatum.Email = data.Email;
                objCusBaseDatum.DocWay = data.DocWay;
                objCusBaseDatum.CustClass = data.CustClass;
                objCusBaseDatum.CreateUser = "Lily1010";
                objCusBaseDatum.CreateDate = DateTime.Now;
                _EFDATAContext.Add(objCusBaseDatum);
                _EFDATAContext.SaveChanges();


                foreach (var TaxResidency in data.TaxResidencyData)
                {
                    TaxResidency objTaxResidency = new TaxResidency();
                    objTaxResidency.FormId = data.FormID;
                    objTaxResidency.FormNo = data.FormNo;
                    objTaxResidency.NationCode = TaxResidency.NationCode;
                    objTaxResidency.NationName = TaxResidency.NationName;
                    objTaxResidency.TaxId = TaxResidency.TaxId;
                    objTaxResidency.ReasonId = TaxResidency.ReasonId;
                    objTaxResidency.ReasonDesc = TaxResidency.ReasonDesc;
                    objTaxResidency.CreateUser = "Lily1010";
                    objTaxResidency.CreateDate = DateTime.Now;
                    _EFDATAContext.Add(objTaxResidency);

                }
                _EFDATAContext.SaveChanges();
                actionResult = Ok(new ApiResult<object>(data));
            }
            catch (Exception e)
            {
                message = e.Message;
                actionResult = NotFound(new ApiError("8888", message));
            }
            return actionResult;
        }


        [HttpGet]
        public IEnumerable<O010000MDTO> HOHO()
        {
            //var result = (from aa in dbContext.OO010000_M 
            //              select temp(aa));
            var result = _EFDATAContext.O010000Ms.Select(a => temp(a));
            return result.ToList();
        }

        private static O010000MDTO temp(O010000M a)
        {
            return new O010000MDTO
            {
                FormId = a.FormID,
                FormNo = a.FormNo,
                CustType = a.CustType,
                Com = a.Com,
                ComName = a.ComName,
                DealAddr = a.DealAddr,
                DealDate = a.DealDate,
                DealUserId = a.DealUserId,
                OpenSales = a.OpenSales,
                OpenSalesName = a.OpenSalesName,
                CustIdno = a.CustIdno,
                CreateUser = a.CreateUser,
                CreateDate = a.CreateDate
            };
        }
    }
}
