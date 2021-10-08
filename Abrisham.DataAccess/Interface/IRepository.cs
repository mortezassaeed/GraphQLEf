using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abrisham.DataAccess.Interface
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        Task<T> CreateAsync(T entity);
    }
}
