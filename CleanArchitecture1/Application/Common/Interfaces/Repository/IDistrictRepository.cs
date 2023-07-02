using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IDistrictRepository : IGenericRepository<District>
    {
        Task<List<District>> GetByCityIdAsync(int cityId);
    }
}
