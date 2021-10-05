using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreApiDemo.DTO;
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

        public OOTempController(EFDATAContext EFDATAContext)
        {
            _EFDATAContext = EFDATAContext;
        }

        [HttpGet("{comp_code}")] //分公司營業員查詢
        public IActionResult GetSalesData(string comp_code)
        {
            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                var result = _EFDATAContext.ViwHsoasales.Where(a => a.Com.Contains(comp_code)).Select(a => new ViewHsoasalesDTO
                {
                    Com = a.Com,
                    ComName = a.ComName,
                    Sales = a.Sales,
                    SalesName = a.SalesName
                }).ToList();
                if (result == null || result.Count() <= 0)
                {
                    throw new Exception("comp_code傳入參數異常");
                }
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
                             select new  { CityName = a.ItemName, Seq = a.Seq };  //不會使用到ViwHsoabirthCityDTO
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

        //[HttpGet]
        //public IActionResult GetApplyData(string comp_code, string user_id, string customer_id)
        //{
        //    string message = string.Empty;
        //    IActionResult? actionResult = null;
        //    try
        //    {
        //        var result = _EFDATAContext.ViwHsoasales.Where(a => a.Com.Contains(comp_code)).Select(a => new ViewHsoasalesDTO
        //        {
        //            Com = a.Com,
        //            ComName = a.ComName,
        //            Sales = a.Sales,
        //            SalesName = a.SalesName
        //        }).ToList();
        //        if (result == null || result.Count() <= 0)
        //        {
        //            throw new Exception("comp_code傳入參數異常");
        //        }
        //        actionResult = Ok(new ApiResult<object>(result));
        //    }
        //    catch (Exception e)
        //    {
        //        message = e.Message;
        //        actionResult = NotFound(new ApiError("5555", message));
        //    }
        //    return actionResult;
        //}


        [HttpPost]
        public IActionResult SetApplyData([FromBody] O010000M data)
        {

            string message = string.Empty;
            IActionResult? actionResult = null;
            try
            {
                if (data.FormNo == null)
                {
                    throw new Exception("FormNo傳入參數異常");
                }
                _EFDATAContext.Add(data);
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

        //post
        //[Route("SetSalesData")]
        //[HttpPost]
        //public IActionResult SetSalesData([FromBody] Class data)
        //{

        //    string message = string.Empty;
        //    IActionResult? actionResult = null;
        //    try
        //    {
        //        if (data.Comp_code == "" || data.Comp_code == null)
        //        {
        //            throw new Exception("comp_code傳入參數異常");
        //        }
        //        var result = _EFDATAContext.ViwHsoasales.AsQueryable();
        //        result = result.Where(a => a.Com.Contains(data.Comp_code));
        //        if (result != null || result.Count() > 0)
        //        {

        //            actionResult = Ok(new ApiResult<object>(result));
        //        }


        //        //response = JsonConvert.SerializeObject(new ApiResult<object>(result));
        //    }
        //    catch (Exception e)
        //    {
        //        //message = e.Message;
        //        //resultData = NotFound( new ApiError("5555", message));
        //        message = e.Message;
        //        actionResult = NotFound(new ApiError("5555", message));
        //    }
        //    return actionResult;
        //}

        // POST api/<OOTempController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<OOTempController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OOTempController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
