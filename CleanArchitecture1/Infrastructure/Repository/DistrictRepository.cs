using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class DistrictRepository : GenericRepository<District>, IDistrictRepository
    {
        private ApplicationDbContext _context;
        public DistrictRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<District>> GetByCityIdAsync(int cityId)
        {
            return await _context.Districts.Where(it => it.CityId == cityId).ToListAsync();
        }
        
    }
}
