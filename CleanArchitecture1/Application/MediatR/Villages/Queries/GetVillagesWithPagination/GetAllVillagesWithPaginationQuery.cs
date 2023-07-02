using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Mappings;
using Application.Common.Models;
using Application.Dto;


namespace Application.Villages.Queries.GetVillagesWithPagination
{
    public class GetAllVillagesWithPaginationQuery : IRequestWrapper<PaginatedList<VillageDto>>
    {
        public int DistrictId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetAllVillagesWithPaginationQueryHandler : IRequestHandlerWrapper<GetAllVillagesWithPaginationQuery, PaginatedList<VillageDto>>
    {
        private readonly IVillageRepository _Repository;
        private readonly IMapper _mapper;

        public GetAllVillagesWithPaginationQueryHandler(IVillageRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PaginatedList<VillageDto>>> Handle(GetAllVillagesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            PaginatedList<VillageDto> list = _mapper.Map<PaginatedList<VillageDto>>(await
                _Repository.GetByDistrictIdAsync(request.DistrictId, request.PageNumber, request.PageSize));
            return list.Items.Any() ? ServiceResult.Success(list) : ServiceResult.Failed<PaginatedList<VillageDto>>(ServiceError.NotFound);
        }
    }
}
