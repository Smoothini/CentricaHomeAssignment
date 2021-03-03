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
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly DBDistrict provider;
        public DistrictController(DBDistrict provider)
        {
            this.provider = provider;
        }
        // GET: api/<DistrictController>
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
        // GETS a list of possible secondary sales persons for 
        // the district with given id
        //
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
        // GETS a list of asigned secondary sales persons for 
        // the district with given id
        //
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
