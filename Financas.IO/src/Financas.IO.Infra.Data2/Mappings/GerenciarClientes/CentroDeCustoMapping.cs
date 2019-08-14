using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Infra.Data2.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Infra.Data2.Mappings.GerenciarClientes
{
    public class CentroDeCustoMapping : EntityTypeConfiguration<CentroDeCusto>
    {
        public override void Map(EntityTypeBuilder<CentroDeCusto> builder)
        {
            builder.Property(cc => cc.Descricao)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Ignore(cc => cc.ValidationResult);

            builder.Ignore(cc => cc.CascadeMode);

            builder.ToTable("CentroDeCustos");
        }
    }
}
