using Manager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks; // Criação dos métodos assíncronos utilizando Tasks.

namespace Manager.Infra.Interfaces
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<T> Create(T obj);
        Task<T> Update(T obj);
        Task Remove(long id);
        Task<T> Get(long id);
        Task<List<T>> Get();

    }
}