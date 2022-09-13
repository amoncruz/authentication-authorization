using Domain.Entities;
using Domain.Enum;
using InfoSolutionTeste.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public  class InfoSolutionContext : DbContext
    {
        public InfoSolutionContext(DbContextOptions<InfoSolutionContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ativo> Ativos { get; set; }
        public DbSet<Carteira> Carteiras { get; set; }
    }
}
