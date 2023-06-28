﻿
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;

namespace cleanarchitecture4.Application.Cities.Queries.GetCities
{
    public class GetAllCitiesQuery : IRequestWrapper<List<CityDto>>
    {

    }

    public class GetCitiesQueryHandler : IRequestHandlerWrapper<GetAllCitiesQuery, List<CityDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<CityDto>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            List<CityDto> list =_mapper.Map<List<CityDto>>( await _context.Cities
                .Include(x => x.Districts)
                .ThenInclude(c => c.Villages)
                .ToListAsync(cancellationToken));

            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<CityDto>>(ServiceError.NotFound);
        }
    }
}
