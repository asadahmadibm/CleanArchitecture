using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id, CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<bool> ExistAsync(int id, CancellationToken cancellationToken);
        Task<T> AddAsync(T entity,CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsynv(T entity, CancellationToken cancellationToken);
    }
}
