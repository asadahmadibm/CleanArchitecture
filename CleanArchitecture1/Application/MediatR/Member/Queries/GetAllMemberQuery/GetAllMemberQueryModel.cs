using Application.Common.Models;
using MediatR;
namespace Application.MediatR.Member.Queries.GetAllMemberQuery
{
    public class GetAllMemberQueryModel : IRequest<List<MemberDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Address { get; set; }
    }
}
