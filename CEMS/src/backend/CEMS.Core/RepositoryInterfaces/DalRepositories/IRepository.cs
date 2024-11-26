using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CEMS.Core.RepositoryInterfaces.DalRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<int> GetCountAsync();
        Task<bool> AnyAsync();
        Task<T> AddAsync(T item);
        Task<List<T>> GetAllAsync();
    }
}
