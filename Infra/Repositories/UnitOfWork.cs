using Domain.Interfaces;
using Infra.Data;

namespace InfoSolutionTeste.Infra.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InfoSolutionContext _context;
        public IUserRepository UserRepository { get; }

        public UnitOfWork(InfoSolutionContext context, IUserRepository users)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            UserRepository = users ?? throw new ArgumentNullException(nameof(users));
        }

        public int Commit()
        {
            return  _context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
