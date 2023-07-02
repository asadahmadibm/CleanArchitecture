using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;
using Domain.Event;

namespace Application.Districts.Commands.Create
{
    public class CreateDistrictCommand : IRequestWrapper<DistrictDto>
    {
        public string Name { get; set; }

        public int CityId { get; set; }
    }

    public class CreateDistrictCommandHandler : IRequestHandlerWrapper<CreateDistrictCommand, DistrictDto>
    {
        private readonly IDistrictRepository _Repository;
        private readonly IMapper _mapper;

        public CreateDistrictCommandHandler(IDistrictRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<DistrictDto>> Handle(CreateDistrictCommand request, CancellationToken cancellationToken)
        {
            var entity = new District
            {
                Name = request.Name,
                CityId = request.CityId
            };

            //await _context.Districts.AddAsync(entity, cancellationToken);

            //await _context.SaveChangesAsync(cancellationToken);

            //return ServiceResult.Success(_mapper.Map<DistrictDto>(entity));

            //var entity = _mapper.Map<District>(request.CityDto);
            //entity.AddDomainEvent(new CityDistrictEvent(entity));
            var result = await _Repository.AddAsync(entity, cancellationToken);
            var resultDto = _mapper.Map<DistrictDto>(result);
            return ServiceResult.Success(resultDto);
        }
    }
}
