using Financas.IO.Domain.CadastrosBasico.PlanosDeContas;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Infra.Data2.Mappings.CadastrosBasico.PlanosDeContas
{
    public class PlanoDeContaMapping : EntityTypeConfiguration<PlanoDeConta>
    {
        public override void Map(EntityTypeBuilder<PlanoDeConta> builder)
        {
            builder.Property(b => b.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Ignore(a => a.ValidationResult);

            builder.Ignore(a => a.CascadeMode);

            builder.ToTable("PlanoDeContas");

            builder.HasOne(pc => pc.GrupoDeConta)
                .WithMany(gc => gc.PlanoDeContas)
                .HasForeignKey(pc => pc.GrupoDeContaId);

        }
    }
}
