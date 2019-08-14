using AutoMapper;
using Financas.IO.Aplication.Interfaces.CadastrosBasico.Agencias;
using Financas.IO.Aplication.Interfaces.CadastrosBasico.Bancos;
using Financas.IO.Aplication.Interfaces.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Aplication.Services.CadastrosBasico.Agencias;
using Financas.IO.Aplication.Services.CadastrosBasico.Bancos;
using Financas.IO.Aplication.Services.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Domain.AgenCadastrosBasico.Agenciascias.Events;
using Financas.IO.Domain.CadastrosBasico.Agencias.Commands;
using Financas.IO.Domain.CadastrosBasico.Agencias.Events;
using Financas.IO.Domain.CadastrosBasico.Agencias.Handlers;
using Financas.IO.Domain.CadastrosBasico.Agencias.Repository;
using Financas.IO.Domain.CadastrosBasico.Bancos.Commands;
using Financas.IO.Domain.CadastrosBasico.Bancos.Events;
using Financas.IO.Domain.CadastrosBasico.Bancos.Handlers;
using Financas.IO.Domain.CadastrosBasico.Bancos.Repository;
using Financas.IO.Domain.Core.Bus;
using Financas.IO.Domain.Core.Events;
using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Events;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Handlers;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Repository;
using Financas.IO.Domain.Interfaces;
using Financas.IO.Infra.CrossCutting.Bus;
using Financas.IO.Infra.CrossCutting.Identity.Models;
using Financas.IO.Infra.CrossCutting.Identity.Services;
using Financas.IO.Infra.Data2.Context;
using Financas.IO.Infra.Data2.Repository.CadastrosBasico.Agencias;
using Financas.IO.Infra.Data2.Repository.GerenciarClientes.ContasCorrente;
using Financas.IO.Infra.Data2.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Financas.IO.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<IUser, AspNetUser>();

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddScoped<IBancoAppService, BancoAppService>();
            services.AddScoped<IAgenciaAppService, AgenciaAppService>();
            services.AddScoped<IContaCorrenteAppService, ContaCorrenteAppService>();


            // Domain - Commands
            services.AddScoped<IHandler<CadastrarBancoCommand>, BancoCommandHandler>();
            services.AddScoped<IHandler<AtualizarBancoCommand>, BancoCommandHandler>();
            services.AddScoped<IHandler<ExcluirBancoCommand>, BancoCommandHandler>();

            services.AddScoped<IHandler<CadastrarAgenciaCommand>, AgenciaCommandHandler>();
            services.AddScoped<IHandler<AtualizarAgenciaCommand>, AgenciaCommandHandler>();
            services.AddScoped<IHandler<ExcluirAgenciaCommand>, AgenciaCommandHandler>();
            services.AddScoped<IHandler<IncluirEnderecoAgenciaCommand>, AgenciaCommandHandler>();
            services.AddScoped<IHandler<AtualizarEnderecoAgenciaCommand>, AgenciaCommandHandler>();

            services.AddScoped<IHandler<CadastrarClienteContaCorrenteCommand>, ContaCorrenteCommandHandler>();
            services.AddScoped<IHandler<AtualizarClienteContaCorrenteCommand>, ContaCorrenteCommandHandler>();
            services.AddScoped<IHandler<ExcluirClienteContaCorrenteCommand>, ContaCorrenteCommandHandler>();

            // Domain - Events
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IHandler<BancoCadastradoEvent>, BancoEventHandler>();
            services.AddScoped<IHandler<BancoAtualizadoEvent>, BancoEventHandler>();
            services.AddScoped<IHandler<BancoExcluidoEvent>, BancoEventHandler>();

            services.AddScoped<IHandler<AgenciaCadastradaEvent>, AgenciaEventHandler>();
            services.AddScoped<IHandler<AgenciaAtualizadaEvent>, AgenciaEventHandler>();
            services.AddScoped<IHandler<AgenciaExcluidaEvent>, AgenciaEventHandler>();
            services.AddScoped<IHandler<EnderecoAgenciaIncluidoEvent>, AgenciaEventHandler>();
            services.AddScoped<IHandler<EnderecoAgenciaAtualizadoEvent>, AgenciaEventHandler>();

            services.AddScoped<IHandler<ClienteContaCorrenteCadastradoEvent>, ContaCorrenteEventHandler>();
            services.AddScoped<IHandler<ClienteContaCorrenteAtualizadoEvent>, ContaCorrenteEventHandler>();
            services.AddScoped<IHandler<ClienteContaCorrenteExcluidoEvent>, ContaCorrenteEventHandler>();

            // Infra - Data
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IAgenciaRepository, AgenciaRepository>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<FinancaEFContext>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();

            // Infra - Identity
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddScoped<IUser, AspNetUser>();

        }
    }
}
