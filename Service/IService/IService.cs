using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.IService
{
    public interface IService<T>
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid Id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(Guid Id);
    }
}
