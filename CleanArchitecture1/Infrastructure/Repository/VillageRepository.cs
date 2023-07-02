using Application.Common.Interfaces.Repository;
using Azure.Core;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class VillageRepository : GenericRepository<Village>, IVillageRepository
    {
        private ApplicationDbContext _context;
        public VillageRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Village>> GetByDistrictIdAsync(int DistrictId, int PageNumber, int PageSize)
        {
            return await _context.Villages
            .Where(x => x.DistrictId == DistrictId)
            .OrderBy(o => o.Name).Take(PageSize).Skip(PageNumber * PageSize).ToListAsync();
        }
       
    }
}
