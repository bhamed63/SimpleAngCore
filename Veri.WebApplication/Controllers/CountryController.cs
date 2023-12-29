using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Veri.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veri.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        ICountryRepository _countryRepository;
        public CountryController(ICountryRepository countryRepository)
        {
                _countryRepository = countryRepository;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            return _countryRepository.GetAll();
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
