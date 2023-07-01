using Domain.Entities;

namespace Application.Common.Interfaces.Repository
{
    public interface IMemberRepository :IGenericRepository<Member>
    {
        Task<List<Member>> GetAllMembersAsync();
    }
}
