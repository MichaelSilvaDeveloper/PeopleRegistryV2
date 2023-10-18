using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.InterfacesServices
{
    public interface IPerson
    {
        Task<List<Person>> ShowPeople();

        Task<Person> GetPersonById(int id);

        Task InsertPerson(Person person);

        Task DeletePerson(int id);

        Task UpdatePerson(Person person, int id);
    }
}