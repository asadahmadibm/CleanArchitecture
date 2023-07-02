using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IVillageRepository : IGenericRepository<Village>
    {
        Task<List<Village>> GetByDistrictIdAsync(int DistrictId, int PageNumber, int PageSize);
    }
}
