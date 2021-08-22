using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OOTempController : ControllerBase
    {
        private readonly EFDATAContext _EFDATAContext;

        public OOTempController(EFDATAContext EFDATAContext)
        {
            _EFDATAContext = EFDATAContext;
        }
        // GET: api/<OOTempController>
        [HttpGet]
        public IEnumerable<TaCompany> Get()
        {
            return _EFDATAContext.TaCompanies;
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
