using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data2.Mappings.CadastrosBasico.Agencias
{
    public class EnderecoMapping : EntityTypeConfiguration<Endereco>
    {
        public override void Map(EntityTypeBuilder<Endereco> builder)
        {
            builder.Property(e => e.Logradouro)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(e => e.Numero)
                .HasColumnType("varchar(10)")
                .IsRequired();

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(250)")
                .IsRequired(false);

            builder.Property(e => e.Bairro)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.CEP)
                .HasColumnType("varchar(8)")
                .IsRequired();

            builder.HasOne(e => e.Agencia)
                .WithOne(a => a.Endereco)
                .HasForeignKey<Endereco>(e => e.AgenciaId)
                .IsRequired(false);

            builder.HasOne(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.CidadeId);

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Enderecos");
        }
    }
}
