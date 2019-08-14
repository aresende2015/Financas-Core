using Financas.IO.Domain.Agencias;
using Financas.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data.Mappings.Agencias
{
    public class AgenciaMapping : EntityTypeConfiguration<Agencia>
    {
        public override void Map(EntityTypeBuilder<Agencia> builder)
        {
            builder.Property(a => a.NumeroDaAgencia)
                .IsRequired();

            builder.Property(a => a.NomeDaAgencia)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Ignore(a => a.ValidationResult);

            builder.Ignore(a => a.CascadeMode);

            builder.ToTable("Agencias");

            builder.HasOne(a => a.Banco)
                .WithMany(b => b.Agencias)
                .HasForeignKey(a => a.BancoId);

            builder.HasOne(a => a.Endereco)
                .WithOne(e => e.Agencia)
                .HasForeignKey<Agencia>(a => a.EnderecoId)
                .IsRequired(false);
        }
    }
}
