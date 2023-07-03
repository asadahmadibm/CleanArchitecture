
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using Domain.Event;
using Domain.Events;
using MediatR;

namespace Application.Cities.Commands.Create
{
    public class CreateCityCommand : IRequestWrapper<CityDto>
    {
        public CreateCityDto createCityDto { get; set; }
    }

    public class CreateCityCommandHandler : IRequestHandlerWrapper<CreateCityCommand, CityDto>
    {
        private readonly ICityRepository _Repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateCityCommandHandler(ICityRepository Repository, IMapper mapper, IMediator mediator)
        {
            _Repository = Repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ServiceResult<CityDto>> Handle(CreateCityCommand request, CancellationToken cancellationToken)
        {
           
            var entity = _mapper.Map<City>(request.createCityDto);
            //entity.AddDomainEvent(new CityCreatedEvent(entity));
            var result = await _Repository.AddAsync(entity, cancellationToken);
            await _mediator.Publish(new CityCreatedEvent(entity));
            var resultDto = _mapper.Map<CityDto>(result);
            return ServiceResult.Success(resultDto);
        }
    }
}
