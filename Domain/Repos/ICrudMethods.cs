using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autokool.Domain.Repos
{
    public interface ICrudMethods<T>
    {
        string ErrorMessage { get; }
        public T EntityInDb { get; }
        Task<List<T>> Get();
        Task<T> Get(string id);
        Task Delete(string id);
        Task Add(T obj);
        Task Update(T obj);
    }
}