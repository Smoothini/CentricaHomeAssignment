using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer.DAO;
using Microsoft.AspNetCore.Mvc;
using API.DtoMapper;
using API.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    /// <summary>
    /// Controller Class for District Entities from the Database
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly DBDistrict provider;
        /// <summary>
        /// Constructor with Injected Database Entity Provider
        /// </summary>
        /// <param name="provider">DBDistrict Database entity</param>
        public DistrictController(DBDistrict provider)
        {
            this.provider = provider;
        }

        // GET: api/<DistrictController>
        /// <summary>
        /// HTTP GET for all Districts list.
        /// </summary>
        /// <returns>
        /// Success: Code 200 + District list.
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

        // GET api/<DistrictController>/5
        /// <summary>
        /// HTTP GET For retrieving a single district.
        /// </summary>
        /// <param name="id">District ID</param>
        /// <returns>
        /// Success: Code 200 + District DTO Object.
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


        // POST api/<DistrictController>
        /// <summary>
        /// HTTP Post For creating a new district.
        /// </summary>
        /// <param name="dto">DTO District Object</param>
        /// <returns>
        /// Success: Code 200 on succesfuly creating the disrict.
        /// Failure: Bad request code.
        /// </returns>
        [HttpPost]
        public IActionResult Post([FromBody] DistrictDto dto)
        {
            try
            {
                provider.Create(dto.toDao());
                return Ok("District created succsessfully.");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // PUT api/<DistrictController>/5
        /// <summary>
        /// HTTP PUT for updating a district.
        /// </summary>
        /// <param name="id">District ID</param>
        /// <param name="dto">District Dto object</param>
        /// <returns>
        /// Success: Code 200 on succesfuly updating the disrict.
        /// Failure: Bad request code.
        /// </returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DistrictDto dto)
        {
            try
            {
                provider.Update(dto.toDao());
                return Ok("District updated successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // DELETE api/<DistrictController>/5
        /// <summary>
        /// HTTP Delete For deleting a single district.
        /// </summary>
        /// <param name="id">District ID</param>
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
                return Ok("District deleted successfully!");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }


        #region SECONDARY SALESPERSON MANAGEMENT

        // GET api/<DistrictController>/getPSSP/5
        /// <summary>
        /// GETS a list of possible secondary sales persons for the district with given id.
        /// </summary>
        /// <param name="id">District ID</param>
        /// <returns>
        /// Success: Code 200 + List of salesperson that can be appended to the district whose Id is passed.
        /// Failure: Bad request
        /// </returns>
        [HttpGet("getPSSP/{id}")]
        public IActionResult GetPSSP(int id)
        {
            try
            {
                return Ok(provider.GetPossibleSecondary(id).allToDto());
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }

        }

        // GET api/<DistrictController>/getASSP/5
        /// <summary>
        /// GETS a list of appended secondary sales persons to the district with given id.
        /// </summary>
        /// <param name="id">District ID</param>
        /// <returns>
        /// Success: Code 200 + List of salesperson that are secondary to the district whose Id is passed.
        /// Failure: Bad request.
        /// </returns>
        [HttpGet("getASSP/{id}")]
        public IActionResult GetASSP(int id)
        {
            try
            {
                return Ok(provider.GetAssignedSecondary(id).allToDto());
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }

        }




        // POST api/<DistrictController>/appendSecondary/d_id/s_id
        /// <summary>
        /// POSTs a new entry in the pivot secondary salesman table, associating a district ID with a salesman ID.
        /// </summary>
        /// <param name="district_id">District ID</param>
        /// <param name="salesperson_id">SalesMan ID</param>
        /// <returns>
        /// Success: Code 200 after making the entry in the pivot.
        /// Failure: Bad request.
        /// </returns>
        [HttpPost("appendSecondary/{district_id}/{salesperson_id}")]
        public IActionResult AppendSecondary(int district_id, int salesperson_id)
        {
            try
            {
                provider.AddSecondary(district_id, salesperson_id);
                return Ok("Secondary Salesperson Appended");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        // DELETE api/<DistrictController>/removeSecondary/d_id/s_id
        /// <summary>
        /// DELETES an entry from the pivot secondary salesman table, associating a district ID with a salesman ID.
        /// </summary>
        /// <param name="district_id">District ID</param>
        /// <param name="salesperson_id">SalesMan ID</param>
        /// <returns>
        /// Success: Code 200 after removing the entry from the pivot.
        /// Failure: Bad request.
        /// </returns>
        [HttpDelete("removeSecondary/{district_id}/{salesperson_id}")]
        public IActionResult RemoveSecondary(int district_id, int salesperson_id)
        {
            try
            {
                provider.RemoveSecondary(district_id, salesperson_id);
                return Ok("Secondary Salesperson Removed");
            }
            catch (Exception e)
            {
                return BadRequest($"ERROR: {e.Message}");
            }
        }

        #endregion

    }
}
