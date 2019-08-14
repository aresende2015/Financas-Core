using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Domain.CadastrosBasico.Bancos;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Infra.Data2.Extensions;
using Financas.IO.Infra.Data2.Mappings.CadastrosBasico.Agencias;
using Financas.IO.Infra.Data2.Mappings.CadastrosBasico.Bancos;
using Financas.IO.Infra.Data2.Mappings.CadastrosBasico.PlanosDeContas;
using Financas.IO.Infra.Data2.Mappings.GerenciarClientes;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Financas.IO.Infra.Data2.Context
{
    public class FinancaEFContext : DbContext
    {
        public DbSet<Agencia> Agencias { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Cidade> Cidades { get; set; }

        public DbSet<Banco> Bancos { get; set; }

        public DbSet<ContaCorrente> ContasCorrentes { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<CentroDeCusto> CentroDeCustos { get; set; }

        public DbSet<Lancamento> Lancamentos { get; set; }

        public DbSet<PlanoDeConta> PlanoDeContas { get; set; }

        public DbSet<GrupoDeConta> GrupoDeContas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<ValidationFailure>();

            modelBuilder.AddConfiguration(new AgenciaMapping());
            modelBuilder.AddConfiguration(new EnderecoMapping());
            modelBuilder.AddConfiguration(new CidadeMapping());
            modelBuilder.AddConfiguration(new BancoMapping());
            modelBuilder.AddConfiguration(new ContaCorrenteMapping());
            modelBuilder.AddConfiguration(new ClienteMapping());
            modelBuilder.AddConfiguration(new CentroDeCustoMapping());
            modelBuilder.AddConfiguration(new LancamentoMapping());
            modelBuilder.AddConfiguration(new PlanoDeContaMapping());
            modelBuilder.AddConfiguration(new GrupoDeContaMapping());

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
