
using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Dto;

namespace Application.Cities.Queries.GetCityById
{
    public class GetMemberByIdQuery : IRequestWrapper<MemberDto>
    {
        public int id { get; set; }
    }

    public class GetMemberByIdQueryHandler : IRequestHandlerWrapper<GetMemberByIdQuery, MemberDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMemberByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<MemberDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _context.Memberss
                .Where(x => x.Id == request.id)
                .FirstOrDefaultAsync(cancellationToken);
            var mamberdto=_mapper.Map<MemberDto>(member);

            return member != null ? ServiceResult.Success(mamberdto) : ServiceResult.Failed<MemberDto>(ServiceError.NotFound);
        }
    }
}
