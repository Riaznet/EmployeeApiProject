using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.IRepositoy
{
    public interface IRepository<T> : IDisposable
        where T : Entity
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid Id);
    }
}
