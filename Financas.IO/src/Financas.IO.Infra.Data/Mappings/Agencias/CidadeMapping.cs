using Financas.IO.Domain.Agencias;
using Financas.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data.Mappings.Agencias
{
    public class CidadeMapping : EntityTypeConfiguration<Cidade>
    {
        public override void Map(EntityTypeBuilder<Cidade> builder)
        {
            builder.Property(c => c.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.UF)
                .HasColumnType("varchar(2)")
                .IsRequired();

            builder.Ignore(a => a.ValidationResult);

            builder.Ignore(a => a.CascadeMode);

            builder.ToTable("Cidades");
        }
    }
}
