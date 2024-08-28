using BoilerPlateBackend.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoilerPlateBackend.Domain.Abstractions;
public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int memberId);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task DeleteMember(int memberId);
}
