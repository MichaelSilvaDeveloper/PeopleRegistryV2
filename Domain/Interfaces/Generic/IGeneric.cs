using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Generic
{
    public interface IGeneric<T> where T : class
    {
        Task<List<T>> Show();

        Task<T> GetById(int id);

        Task Insert(T Objeto);

        Task Delete(T Objeto);

        Task Update(T Objeto);
    }
}