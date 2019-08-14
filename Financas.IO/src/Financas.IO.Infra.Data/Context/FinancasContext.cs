using Financas.IO.Domain.Agencias;
using Financas.IO.Domain.Bancos;
using Financas.IO.Infra.Data.Extensions;
using Financas.IO.Infra.Data.Mappings.Agencias;
using Financas.IO.Infra.Data.Mappings.Bancos;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Financas.IO.Infra.Data.Context
{
    public class FinancasContext : DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Banco> Bancos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.AddConfiguration(new AgenciaMapping());
            modelBuilder.AddConfiguration(new EnderecoMapping());
            modelBuilder.AddConfiguration(new CidadeMapping());
            modelBuilder.AddConfiguration(new BancoMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
