using Financas.IO.Domain.Bancos;
using Financas.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data.Mappings.Bancos
{
    public class BancoMapping : EntityTypeConfiguration<Banco>
    {
        public override void Map(EntityTypeBuilder<Banco> builder)
        {
            builder.Property(b => b.Descricao)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Ignore(a => a.ValidationResult);

            builder.Ignore(a => a.CascadeMode);

            builder.ToTable("Bancos");

        }
    }
}
