
using Application.Common.Interfaces;
using Application.Common.Interfaces.Repository;
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
        private IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public GetMemberByIdQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<MemberDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            var member = await _memberRepository.GetAsync(request.id, cancellationToken);

            var mamberdto=_mapper.Map<MemberDto>(member);

            return member != null ? ServiceResult.Success(mamberdto) : ServiceResult.Failed<MemberDto>(ServiceError.NotFound);
        }
    }
}
