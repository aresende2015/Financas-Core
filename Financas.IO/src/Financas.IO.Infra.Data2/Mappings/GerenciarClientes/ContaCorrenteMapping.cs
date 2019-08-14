using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data2.Mappings.GerenciarClientes
{
    public class ContaCorrenteMapping : EntityTypeConfiguration<ContaCorrente>
    {
        public override void Map(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.Property(cc => cc.NumeroDaContaCorrente)
                .IsRequired();

            builder.Ignore(cc => cc.ValidationResult);

            builder.Ignore(cc => cc.CascadeMode);

            builder.ToTable("ContasCorrentes");

            builder.HasOne(cc => cc.Cliente)
                .WithMany(c => c.ContasCorrentes)
                .HasForeignKey(cc => cc.ClienteId);

            builder.HasOne(cc => cc.Agencia)
                .WithMany(a => a.ContasCorrentes)
                .HasForeignKey(cc => cc.AgenciaId);
        }
    }
}
