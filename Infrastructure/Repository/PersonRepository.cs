using Domain.Interfaces.InterfacesServices;
using Entities.Entities;
using Infrastructure.Configuration;
using Infrastructure.Repository.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPerson
    {
        private readonly DbContextOptions<PeopleRegistryDBContext> _dBContext;

        public PersonRepository()
        {
            _dBContext = new DbContextOptions<PeopleRegistryDBContext>();
        }

        public async Task<List<Person>> ShowPeople()
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                return await data.Pessoa.ToListAsync();
            }
        }

        public async Task<Person> GetPersonById(int id)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                return await data.Pessoa.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task InsertPerson(Person person)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                await data.Pessoa.AddAsync(person);
                await data.SaveChangesAsync();
            }
        }

        public async Task DeletePerson(int id)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                var removePersonById = await GetPersonById(id);
                if (removePersonById == null)
                    throw new Exception($"Usuário para o id: {id} não foi encontrado");
                data.Pessoa.Remove(removePersonById);
                await data.SaveChangesAsync();
            }
        }

        public async Task UpdatePerson(Person person, int id)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                var editPersonById = await GetPersonById(id);
                if (editPersonById == null)
                    throw new Exception($"Usuário para o id: {id} não foi encontrado");
                editPersonById.Name = person.Name;
                editPersonById.Email = person.Email;
                data.Pessoa.Remove(editPersonById);
                await data.SaveChangesAsync();
            }
        }
    }
}