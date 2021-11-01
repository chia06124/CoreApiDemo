using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using CoreApiDemo.DTO;
using CoreApiDemo.DTO.Info;
using CoreApiDemo.Models;
using CoreApiDemo.Models.Interface;
using CoreApiDemo.Models.Repository;
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
        public IActionResult GetSalesData(string? comp_code=null)
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            
            try
            {
                if (comp_code == null)
                {
                    throw new Exception("comp_code傳入參數異常");
                }
                IRepository<ViewHsoasalesDTO> _ViewHsoasales = new SalesDataRepository<ViewHsoasalesDTO>();
                var result = _ViewHsoasales.GetById(_EFDATAContext, comp_code);
                actionResult = Ok(new ApiResult<object>(result));
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
                IRepository<ViwHsoabirthCountryDTO> _ViwHsoabirthCountry = new CountryDataRepository<ViwHsoabirthCountryDTO>();
                var result = _ViwHsoabirthCountry.GetAll(_EFDATAContext);
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
                IRepository<ViwHsoabirthCityDTO> _ViwHsoabirthCityDTO = new CityDataRepository<ViwHsoabirthCityDTO>();
                var result = _ViwHsoabirthCityDTO.GetAll(_EFDATAContext);
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

        [HttpPost]
        public IActionResult GetApplyData(JsonElement data)
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                IRepositoryObject<O010000MDTO> _O010000M = new O010000MRepository<O010000MDTO>();
                var result = _O010000M.GetAll(_EFDATAContext, data);
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
        public IActionResult SetApplyData([FromBody] O010000MDTO data)
        {

            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                if (data.FormNo == null)
                {
                    throw new Exception("FormNo傳入參數異常");
                }
                IRepositoryObject<O010000MDTO> _O010000M = new O010000MRepository<O010000MDTO>();
                var result = _O010000M.SetData(_EFDATAContext, data);
                actionResult = Ok(new ApiResult<object>(result));
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
                objCusBaseDatum.FormID = data.FormID;
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
                    objTaxResidency.FormID = data.FormID;
                    objTaxResidency.FormNo = data.FormNo;
                    objTaxResidency.NationCode = TaxResidency.NationCode;
                    objTaxResidency.NationName = TaxResidency.NationName;
                    objTaxResidency.TaxID = TaxResidency.TaxID;
                    objTaxResidency.ReasonID = TaxResidency.ReasonID;
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
        public IEnumerable<O010000MDTO_Temp> HOHO()
        {
            //var result = (from aa in dbContext.OO010000_M 
            //              select temp(aa));
            var result = _EFDATAContext.O010000Ms.Select(a => temp(a));
            return result.ToList();
        }

        private static O010000MDTO_Temp temp(O010000M a)
        {
            return new O010000MDTO_Temp
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
