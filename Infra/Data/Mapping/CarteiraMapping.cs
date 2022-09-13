using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Mapping
{
    public class CarteiraMapping : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            builder.ToTable("Ativos");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithOne().HasForeignKey<Carteira>(fk => fk.UserId);
        }
    }
}
