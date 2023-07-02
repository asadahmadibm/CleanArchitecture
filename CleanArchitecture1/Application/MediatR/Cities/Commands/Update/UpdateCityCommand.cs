
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;

namespace Application.Cities.Commands.Update
{
    public class UpdateCityCommand : IRequestWrapper<CityDto>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }
    }

    public class UpdateCityCommandHandler : IRequestHandlerWrapper<UpdateCityCommand, CityDto>
    {
        private readonly ICityRepository _Repository;
        private readonly IMapper _mapper;

        public UpdateCityCommandHandler(ICityRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<CityDto>> Handle(UpdateCityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _Repository.GetAsync(request.Id,cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(City), request.Id.ToString());
            }
            if (!string.IsNullOrEmpty(request.Name))
                entity.Name = request.Name;
            entity.Active = request.Active;

            var result=await _Repository.UpdateAsync(entity, cancellationToken);

            return ServiceResult.Success(_mapper.Map<CityDto>(result));
        }
    }
}
