using BoilerPlateBackend.Domain.Abstractions;
using BoilerPlateBackend.Domain.Entities;
using BoilerPlateBackend.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BoilerPlateBackend.Infrastructure.Repositories;
public class MemberRepository(AppDbContext db) : IMemberRepository
{
    protected readonly AppDbContext _db = db;

    public async Task<Member> GetMemberById(int memberId)
    {
        var member = await _db.Members.FindAsync(memberId);

        if(member is null)
            throw new InvalidOperationException("Member not found");

        return member;
    }

    public async Task<IEnumerable<Member>> GetMembers()
    {
        var members = await _db.Members.ToListAsync();
        return members ?? Enumerable.Empty<Member>();
    }

    public async Task<Member> AddMember(Member member)
    {
        if(member is null)
            throw new ArgumentNullException(nameof(member));

        await _db.Members.AddAsync(member);
        return member;
    }

    public void UpdateMember(Member member)
    {
        if (member is null)
            throw new ArgumentNullException(nameof(member));

        _db.Members.Update(member);
    }

    public async Task DeleteMember(int memberId)
    {
        var member = await GetMemberById(memberId);

        if(member is null)
            throw new InvalidOperationException("Member not found");

        _db.Members.Remove(member);
    }
}
