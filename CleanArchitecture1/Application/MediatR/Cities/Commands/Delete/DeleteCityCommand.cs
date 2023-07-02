using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using Domain.Entities;

namespace Application.Cities.Commands.Delete
{
    public class DeleteCityCommand : IRequestWrapper<CityDto>
    {
        public int Id { get; set; }
    }

    public class DeleteCityCommandHandler : IRequestHandlerWrapper<DeleteCityCommand, CityDto>
    {
        private readonly ICityRepository _Repository;
        private readonly IMapper _mapper;

        public DeleteCityCommandHandler(ICityRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CityDto>> Handle(DeleteCityCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _context.Cities
            //    .Where(l => l.Id == request.Id)
            //    .SingleOrDefaultAsync(cancellationToken);

            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(City), request.Id.ToString());
            //}

            //_context.Cities.Remove(entity);

            //await _context.SaveChangesAsync(cancellationToken);

            var entity =await _Repository.GetAsync(request.Id,cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(City), request.Id.ToString());
            }
            var result = _Repository.DeleteAsynv(entity, cancellationToken);

            return ServiceResult.Success(_mapper.Map<CityDto>(entity));
        }
    }
}
