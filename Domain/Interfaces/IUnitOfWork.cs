using InfoSolutionTeste.Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        int Commit();
    }
}
