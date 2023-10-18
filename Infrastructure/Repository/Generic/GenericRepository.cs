using Domain.Interfaces.Generic;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Generic
{
    
    public class GenericRepository<T> : IGeneric<T> where T : class
    {
        private readonly DbContextOptions<PeopleRegistryDBContext> _dBContext;

        public GenericRepository()
        {
            _dBContext = new DbContextOptions<PeopleRegistryDBContext>();
        }

        public async Task<List<T>> Show()
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                return await data.Set<T>().AsNoTracking().ToListAsync();
            }
        }

        public async Task<T> GetById(int id)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task Insert(T Objeto)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objeto)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Update(T Objeto)
        {
            using (var data = new PeopleRegistryDBContext(_dBContext))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }
    }
    
}