using System;
using Microsoft.AspNetCore.Mvc;
using DataLayer.DAO;
using DataLayer;
using API.Dto;
using API.DtoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly DBStore provider;
        public StoreController(DBStore provider)
        {
            this.provider = provider;
        }

        // GET: api/<StoreController>
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

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var storedto = provider.Get(id).toDto();
                return Ok(storedto);
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // POST api/<StoreController>
        [HttpPost]
        public IActionResult Post([FromBody] StoreDto storedto)
        {
            try
            {
                provider.Create(storedto.toDao());
                return Ok("Store created succsessfully.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
            
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StoreDto storedto)
        {
            try
            {
                provider.Update(storedto.toDao());
                return Ok("Store updated successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
            
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                provider.Delete(id);
                return Ok("Store deleted successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }
    }
}
