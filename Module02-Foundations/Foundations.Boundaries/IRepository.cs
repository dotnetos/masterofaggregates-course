using System;
using System.Threading.Tasks;

namespace Foundations.Boundaries
{
    public interface IRepository<T>
    {
        Task<T> Get(Guid id);
        Task Update(Guid id, T item);
    }
}