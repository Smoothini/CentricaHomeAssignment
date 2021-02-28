using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DataLayer.DAO;
using DataLayer.Model;
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
        public IEnumerable<StoreDto> Get()
        {
            var storesdto = new List<StoreDto>();
            try 
            {
                return provider.GetAll().allToDto();
            }
            catch(Exception e)
            { }
            return storesdto;
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public StoreDto Get(int id)
        {
            return provider.Get(id).toDto();
        }

        // POST api/<StoreController>
        [HttpPost]
        public StoreDto Post([FromBody] Store store)
        {
            if (store != null)
            {
                try
                {
                    provider.Create(store);
                }
                catch(Exception e)
                {

                }
            }
            return store.toDto();
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Store store)
        {
            try
            {
                provider.Update(store);
            }
            catch (Exception e)
            {

            }
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                provider.Delete(id);
            }
            catch (Exception e)
            {

            }
        }
    }
}
