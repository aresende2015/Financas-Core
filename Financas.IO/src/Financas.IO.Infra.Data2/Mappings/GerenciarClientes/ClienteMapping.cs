using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data2.Mappings.GerenciarClientes
{
    public class ClienteMapping : EntityTypeConfiguration<Cliente>
    {
        public override void Map(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(c => c.CPF)
                .HasColumnType("varchar(11)")
                .IsRequired();

            builder.Property(c => c.DataDeNascimento)
                .IsRequired();

            builder.Ignore(cc => cc.ValidationResult);

            builder.Ignore(cc => cc.CascadeMode);

            builder.ToTable("Clientes");
        }
    }
}
