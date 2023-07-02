using Application.ApplicationUser.Queries.GetToken;
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using cleanarchitecture4.Application.Cities.Queries.GetCities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Ecarsales.Queries.GetAllEcarSaleQuery
{
    public class GetAllEcarsaleQuery : IRequestWrapper<List<EcarsaleDTO>>
    {
    }
    public class GetAllEcarsalesHandler : IRequestHandlerWrapper<GetAllEcarsaleQuery, List<EcarsaleDTO>>
    {
        private readonly IEcarsaleRepository _ecarsalesRepository;
        private readonly IMapper _mapper;

        public GetAllEcarsalesHandler(IEcarsaleRepository ecarsalesRepository, IMapper mapper)
        {
            _ecarsalesRepository = ecarsalesRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<List<EcarsaleDTO>>> Handle(GetAllEcarsaleQuery request, CancellationToken cancellationToken)
        {
            var result = await _ecarsalesRepository.GetAllAsync(cancellationToken);
            var list = _mapper.Map<List<EcarsaleDTO>>(result);
            return list.Count > 0 ? ServiceResult.Success(list) : ServiceResult.Failed<List<EcarsaleDTO>>(ServiceError.NotFound);
        }
    }
}
