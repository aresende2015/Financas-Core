using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data2.Mappings.CadastrosBasico.Agencias
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
