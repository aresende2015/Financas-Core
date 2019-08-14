using Financas.IO.Domain.CadastrosBasico.PlanosDeContas;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data2.Mappings.CadastrosBasico.PlanosDeContas
{
    public class GrupoDeContaMapping : EntityTypeConfiguration<GrupoDeConta>
    {
        public override void Map(EntityTypeBuilder<GrupoDeConta> builder)
        {
            builder.Property(b => b.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Ignore(a => a.ValidationResult);

            builder.Ignore(a => a.CascadeMode);

            builder.ToTable("GrupoDeContas");

        }
    }
}
