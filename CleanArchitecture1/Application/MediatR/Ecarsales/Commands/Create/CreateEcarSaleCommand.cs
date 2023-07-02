using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.Dto;
using Application.MediatR.Ecarsales.Queries;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MediatR.Ecarsales.Commands.Create
{
    public class CreateEcarSaleCommand : IRequestWrapper<EcarsaleDTO>
    {
        public EcarsaleDTO ecarsaleDTO { get; set; }
    }

    public class CreateEcarSaleHandler : IRequestHandlerWrapper<CreateEcarSaleCommand, EcarsaleDTO>
    {
        private readonly IEcarsaleRepository _Repository;
        private readonly IMapper _mapper;

        public CreateEcarSaleHandler(IEcarsaleRepository Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }
        public async Task<ServiceResult<EcarsaleDTO>> Handle(CreateEcarSaleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Ecarsale>(request.ecarsaleDTO);
            var result = await _Repository.AddAsync(entity, cancellationToken);
            var resultDto = _mapper.Map<EcarsaleDTO>(result);
            return ServiceResult.Success(resultDto);
        }
    }
}
