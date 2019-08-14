using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financas.IO.Infra.Data2.Extensions
{
    public abstract class EntityTypeConfiguration<TEntity> where TEntity : class
    {
        public abstract void Map(EntityTypeBuilder<TEntity> builder);
    }
}
