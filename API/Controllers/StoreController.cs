using System;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using API.DtoMapper;
using DataLayer.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    /// <summary>
    /// Controller Class for Store Entities from the Database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly DBStore provider;
        /// <summary>
        /// Constructor with Injected Database Entity Provider
        /// </summary>
        /// <param name="provider">DBStore Database entity</param>
        public StoreController(DBStore provider)
        {
            this.provider = provider;
        }

        // GET: api/<StoreController>
        /// <summary>
        /// HTTP GET for all Stores list.
        /// </summary>
        /// <returns>
        /// Success: Code 200 + Stores list.
        /// Failure: Bad request code.
        /// </returns>
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
        /// <summary>
        /// HTTP GET For retrieving a single store.
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>
        /// Success: Code 200 + Store DTO Object.
        /// Failure: Bad request code.
        /// </returns>
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
        /// <summary>
        /// HTTP Post For creating a new store.
        /// </summary>
        /// <param name="storedto">DTO Store Object</param>
        /// <returns>
        /// Success: Code 200 on succesfuly creating the store.
        /// Failure: Bad request code.
        /// </returns>
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
        /// <summary>
        /// HTTP PUT for updating a store.
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <param name="dto">Store Dto object</param>
        /// <returns>
        /// Success: Code 200 on succesfuly updating the store.
        /// Failure: Bad request code.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StoreDto dto)
        {
            try
            {
                provider.Update(dto.toDao());
                return Ok("Store updated successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
            
        }

        // DELETE api/<StoreController>/5
        /// <summary>
        /// HTTP Delete For deleting a single store.
        /// </summary>
        /// <param name="id">Store ID</param>
        /// <returns>
        /// Success: Code 200.
        /// Failure: Bad request code.
        /// </returns>
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
