using System;
using Microsoft.AspNetCore.Mvc;
using API.Dto;
using API.DtoMapper;
using DataLayer.DAO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    /// <summary>
    /// Controller Class for Salesperson Entities from the Database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SalesPersonController : ControllerBase
    {
        private readonly DBSalesPerson provider;
        /// <summary>
        /// Constructor with Injected Database Entity Provider
        /// </summary>
        /// <param name="provider">DBSalesPerson Database entity</param>
        public SalesPersonController(DBSalesPerson provider)
        {
            this.provider = provider;
        }

        // GET: api/<SalesPersonController>
        /// <summary>
        /// HTTP GET for all Salespersons list.
        /// </summary>
        /// <returns>
        /// Success: Code 200 + Salesperson list.
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

        // GET api/<SalesPersonController>/5
        /// <summary>
        /// HTTP GET For retrieving a single salesperson.
        /// </summary>
        /// <param name="id">Salesperson ID</param>
        /// <returns>
        /// Success: Code 200 + Salesperson DTO Object.
        /// Failure: Bad request code.
        /// </returns>
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
        /// <summary>
        /// HTTP Post For creating a new salesperson.
        /// </summary>
        /// <param name="dto">DTO Salesperson Object</param>
        /// <returns>
        /// Success: Code 200 on succesfuly creating the salesperson.
        /// Failure: Bad request code.
        /// </returns>
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
        /// <summary>
        /// HTTP PUT for updating a salesperson.
        /// </summary>
        /// <param name="id">Salesperson ID</param>
        /// <param name="dto">Salesperson Dto object</param>
        /// <returns>
        /// Success: Code 200 on succesfuly updating the salesperson.
        /// Failure: Bad request code.
        /// </returns>
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
        /// <summary>
        /// HTTP Delete For deleting a single salesperson.
        /// </summary>
        /// <param name="id">Salesperson ID</param>
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
                return Ok("Salesperson deleted successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }
    }
}
