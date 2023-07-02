using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CityRepository : GenericRepository<City>, ICityRepository
    {
        private ApplicationDbContext _context;
        public CityRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllByIncludeAsync(CancellationToken cancellationToken)
        {
            return await _context.Cities
               .Include(x => x.Districts)
               .ThenInclude(c => c.Villages)
               .ToListAsync(cancellationToken);

        }
    }
}
