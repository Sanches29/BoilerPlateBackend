using BoilerPlateBackend.Domain.Abstractions;
using BoilerPlateBackend.Infrastructure.Context;

namespace BoilerPlateBackend.Infrastructure.Repositories;
public class UnitOfWork(AppDbContext db) : IUnitOfWork, IDisposable
{
    private IMemberRepository? _memberRepository;

    public IMemberRepository MemberRepository
    {
        get
        {
            return _memberRepository = _memberRepository ?? new MemberRepository(db);
        }
    }

    public async Task CommitAsync() =>
        await db.SaveChangesAsync();

    public void Dispose() =>
        db.Dispose();
}
