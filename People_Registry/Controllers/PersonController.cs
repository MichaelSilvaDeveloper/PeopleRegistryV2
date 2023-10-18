using Application.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People_Registry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonApplication _iPersonApplication;

        public PersonController(IPersonApplication iPersonApplication)
        {
            _iPersonApplication = iPersonApplication;
        }

        [HttpGet]
        public async Task<List<Person>> ShowPeople()
        {
            return await _iPersonApplication.ShowPeople();
        }

        [HttpGet("{id}")]
        public async Task<Person> GetPersonById(int id)
        {
            return await _iPersonApplication.GetPersonById(id);
        }

        [HttpPost]
        public async Task InsertPerson([FromBody] Person person)
        {
            await _iPersonApplication.InsertPerson(person);
        }

        [HttpDelete("{id}")]
        public async Task DeletePerson(int id)
        {
            await _iPersonApplication.DeletePerson(id);
        }

        [HttpPut("{id}")]
        public async Task UpdatePerson([FromBody] Person person, int id)
        {
            await _iPersonApplication.UpdatePerson(person, id);
        }
    }
}