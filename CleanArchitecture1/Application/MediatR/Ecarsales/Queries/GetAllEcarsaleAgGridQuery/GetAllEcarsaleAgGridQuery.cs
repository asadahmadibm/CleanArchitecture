using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Common.Models.AgGrid;
using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Ecarsales.Queries.GetAllEcarsaleAgGridQuery
{
    public class GetAllEcarsaleAgGridQuery : IRequestWrapper<ResultMessage>
    {
        public ServerRowsRequest serverRowsRequest { get; set; }
    }

    public class GetAllEcarsaleAgGridQueryHandler : IRequestHandlerWrapper<GetAllEcarsaleAgGridQuery, ResultMessage>
    {
        private readonly IEcarsaleRepository _ecarsalesRepository;
        private readonly IMapper _mapper;

        public GetAllEcarsaleAgGridQueryHandler(IEcarsaleRepository ecarsalesRepository, IMapper mapper)
        {
            _ecarsalesRepository = ecarsalesRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<ResultMessage>> Handle(GetAllEcarsaleAgGridQuery request, CancellationToken cancellationToken)
        {
            
            return ServiceResult.Success(await _ecarsalesRepository.GetProfiles(request.serverRowsRequest));

        }
    }

}
