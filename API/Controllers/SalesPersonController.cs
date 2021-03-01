using System;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using API.DtoMapper;
using DataLayer.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPersonController : ControllerBase
    {
        private readonly DBSalesPerson provider;
        public SalesPersonController(DBSalesPerson provider)
        {
            this.provider = provider;
        }
        // GET: api/<SalesPersonController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(provider.GetAll().allToDto());
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // GET api/<SalesPersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var dto = provider.Get(id).toDto();
                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // POST api/<SalesPersonController>
        [HttpPost]
        public IActionResult Post([FromBody] SalesPersonDto dto)
        {
            try
            {
                provider.Create(dto.toDao());
                return Ok("Salesperson created succsessfully.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // PUT api/<SalesPersonController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SalesPersonDto dto)
        {
            try
            {
                provider.Update(dto.toDao());
                return Ok("Salesperson updated successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // DELETE api/<SalesPersonController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                provider.Delete(id);
                return Ok("Salesperson deleted successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }
    }
}
