using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface ICityRepository : IGenericRepository<City>
    {
        //Task<List<Ecarsale>> GetAllEcarsalesAsync();
        Task<List<City>> GetAllByIncludeAsync(CancellationToken cancellationToken);
    }
}
