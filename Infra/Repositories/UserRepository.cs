using Domain.Interfaces;
using InfoSolutionTeste.Domain.Entities;
using InfoSolutionTeste.Infra.Repositories;
using Infra.Data;

namespace Infra.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InfoSolutionContext context) : base(context)
        {

        }
    }
}
