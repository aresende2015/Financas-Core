using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Infra.Data2.Mappings.GerenciarClientes
{
    public class LancamentoMapping : EntityTypeConfiguration<Lancamento>
    {
        public override void Map(EntityTypeBuilder<Lancamento> builder)
        {
            builder.Property(l => l.Sequencial)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(l => l.Observacao)
                .HasColumnType("varchar(200)");

            builder.Ignore(l => l.ValidationResult);

            builder.Ignore(l => l.CascadeMode);

            builder.ToTable("Lancamentos");

            builder.HasOne(l => l.CentroDeCusto)
                .WithMany(cc => cc.Lancamentos)
                .HasForeignKey(l => l.CentroDeCustoId);

            builder.HasOne(l => l.PlanoDeConta)
                .WithMany(pc => pc.Lancamentos)
                .HasForeignKey(l => l.PlanoDeContaId);

            builder.HasOne(l => l.ContaCorrente)
                .WithMany(cc => cc.Lancamentos)
                .HasForeignKey(l => l.ContaCorrenteId);
        }
    }
}
