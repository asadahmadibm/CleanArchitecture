
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;

namespace cleanarchitecture4.Application.Cities.Queries.GetCities
{
    public class GetAllCitiesQuery : IRequestWrapper<List<CityDto>>
    {

    }

    public class GetCitiesQueryHandler : IRequestHandlerWrapper<GetAllCitiesQuery, List<CityDto>>
    {
        private readonly ICityRepository _Repository;
        private readonly IMapper _mapper;

        public GetCitiesQueryHandler(ICityRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<CityDto>>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
        {
            List<CityDto> list = _mapper.Map<List<CityDto>>(await _Repository.GetAllByIncludeAsync(cancellationToken));
            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<CityDto>>(ServiceError.NotFound);
        }
    }
}
