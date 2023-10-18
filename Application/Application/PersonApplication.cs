using Application.Interfaces;
using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Application
{
    public class PersonApplication : IPersonApplication
    {
        IPerson _iPerson;

        public PersonApplication(IPerson iPerson)
        {
            _iPerson = iPerson;
        }

        public async Task<List<Person>> ShowPeople()
        {
            return await _iPerson.ShowPeople();
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await _iPerson.GetPersonById(id);
        }

        public async Task InsertPerson(Person person)
        {
            await _iPerson.InsertPerson(person);
        }

        public async Task DeletePerson(int id)
        {
            await _iPerson.DeletePerson(id);
        }

        public async Task UpdatePerson(Person person, int id)
        {
            await _iPerson.UpdatePerson(person, id);
        }
    }
}