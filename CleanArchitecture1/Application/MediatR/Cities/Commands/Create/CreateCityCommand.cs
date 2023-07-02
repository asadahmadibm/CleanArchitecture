
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using Domain.Event;
using Domain.Events;

namespace Application.Cities.Commands.Create
{
    public class CreateCityCommand : IRequestWrapper<CityDto>
    {
        public CityDto CityDto  { get; set; }
    }

    public class CreateCityCommandHandler : IRequestHandlerWrapper<CreateCityCommand, CityDto>
    {
        private readonly ICityRepository _Repository;
        private readonly IMapper _mapper;

        public CreateCityCommandHandler(ICityRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
           
            var entity = _mapper.Map<City>(request.CityDto);
            entity.AddDomainEvent(new CityCreatedEvent(entity));
            var result = await _Repository.AddAsync(entity, cancellationToken);
            var resultDto = _mapper.Map<CityDto>(result);
            return ServiceResult.Success(resultDto);
        }
    }
}
