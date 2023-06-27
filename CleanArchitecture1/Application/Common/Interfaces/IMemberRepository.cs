using Domain.Entities;

namespace Application.Common.Interfaces
{
    public interface IMemberRepository
    {
        Task<List<Member>> GetAllMembersAsync();
    }
}
