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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OOTempController : ControllerBase
    {
        private readonly EFDATAContext _EFDATAContext;
        //private readonly IDbConnection _conn;

        public OOTempController(EFDATAContext EFDATAContext)

        {
            _EFDATAContext = EFDATAContext;
            //this._conn = conn;
        }
        // GET: api/<OOTempController>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _EFDATAContext.TaCompanies.Include(a => a.TaSale01).Select(a => new TaCompanyDTO
            {
                Com = a.Com,
                Cosy=a.Cosy,
                ComName=a.ComName,
                Status=a.Status,
                Address=a.Address,
                PhoneNo=a.PhoneNo,
                Fax=a.Fax,
                CreateDate=a.CreateDate,
                UpdateDate=a.UpdateDate,
                UpdateUerName=a.TaSale01.SalesName
            }) ;

            if (result==null || result.Count() == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        // GET api/<OOTempController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OOTempController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

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
