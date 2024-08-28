using System.Threading.Tasks;

namespace BoilerPlateBackend.Domain.Abstractions;
public interface IUnitOfWork
{
    IMemberRepository MemberRepository { get; }
    Task CommitAsync();
}
