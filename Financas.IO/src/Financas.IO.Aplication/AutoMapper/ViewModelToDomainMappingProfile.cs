using AutoMapper;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Bancos;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.PlanosDeContas;
using Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Domain.CadastrosBasico.Agencias.Commands;
using Financas.IO.Domain.CadastrosBasico.Bancos.Commands;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente.Commands;
using System;

namespace Financas.IO.Aplication.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Agencias
            CreateMap<AgenciaViewModel, CadastrarAgenciaCommand>()
                .ConstructUsing(
                    a => new CadastrarAgenciaCommand(a.NumeroDaAgencia, a.NomeDaAgencia, a.BancoId, a.DataDeCadastro, 
                             a.Ativo, new IncluirEnderecoAgenciaCommand(a.Endereco.Id, a.Endereco.Logradouro, 
                                            a.Endereco.Numero, a.Endereco.Complemento, a.Endereco.Bairro, 
                                            a.Endereco.CEP, a.Endereco.CidadeId, a.Id, a.DataDeCadastro, a.Ativo)));

            CreateMap<AgenciaViewModel, AtualizarAgenciaCommand>()
                .ConstructUsing(a => new AtualizarAgenciaCommand(a.Id, a.NumeroDaAgencia, a.NomeDaAgencia, a.BancoId));

            CreateMap<AgenciaViewModel, ExcluirAgenciaCommand>()
                .ConstructUsing(a => new ExcluirAgenciaCommand(a.Id));

            CreateMap<EnderecoViewModel, IncluirEnderecoAgenciaCommand>()
                .ConstructUsing(e => new IncluirEnderecoAgenciaCommand(
                                            Guid.NewGuid(), e.Logradouro, e.Numero, e.Complemento, e.Bairro, e.CEP, 
                                            e.CidadeId, e.AgenciaId, e.DataDeCadastro, e.Ativo));

            CreateMap<EnderecoViewModel, AtualizarEnderecoAgenciaCommand>()
                .ConstructUsing(e => new AtualizarEnderecoAgenciaCommand(
                                            e.Id, e.Logradouro, e.Numero, e.Complemento, e.Bairro, e.CEP,
                                            e.CidadeId, e.AgenciaId, e.DataDeCadastro, e.Ativo));

            #endregion

            #region Bancos
            CreateMap<BancoViewModel, CadastrarBancoCommand>()
                .ConstructUsing(b => new CadastrarBancoCommand(b.Descricao, b.DataDeCadastro, b.Ativo));

            CreateMap<BancoViewModel, AtualizarBancoCommand>()
                .ConstructUsing(b => new AtualizarBancoCommand(b.Id, b.Descricao));

            CreateMap<BancoViewModel, ExcluirBancoCommand>()
                .ConstructUsing(b => new ExcluirBancoCommand(b.Id));
            #endregion
                       
            #region PlanosDeContas
            CreateMap<PlanoDeContaViewModel, CadastrarPlanoDeContaCommand>()
                .ConstructUsing(pc => new CadastrarPlanoDeContaCommand(pc.Descricao, pc.TipoDeMovimento, 
                                            pc.GrupoDeContadId, pc.DataDeCadastro, pc.Ativo));

            CreateMap<PlanoDeContaViewModel, AtualizarPlanoDeContaCommand>()
                .ConstructUsing(pc => new AtualizarPlanoDeContaCommand(pc.Id, pc.Descricao, pc.TipoDeMovimento, pc.GrupoDeContadId));

            CreateMap<PlanoDeContaViewModel, ExcluirPlanoDeContaCommand>()
                .ConstructUsing(pc => new ExcluirPlanoDeContaCommand(pc.Id));

            CreateMap<GrupoDeContaViewModel, CadastrarGrupoDeContaPlanoDeContaCommand>()
                .ConstructUsing(gc => new CadastrarGrupoDeContaPlanoDeContaCommand(gc.Descricao, gc.DataDeCadastro,gc.Ativo));

            CreateMap<GrupoDeContaViewModel, AtualizarGrupoDeContaPlanoDeContaCommand>()
                .ConstructUsing(gc => new AtualizarGrupoDeContaPlanoDeContaCommand(gc.Id, gc.Descricao));

            CreateMap<GrupoDeContaViewModel, ExcluirGrupoDeContaPlanoDeContaCommand>()
                .ConstructUsing(gc => new ExcluirGrupoDeContaPlanoDeContaCommand(gc.Id));

            #endregion

            #region ContasCorrente
            CreateMap<CentroDeCustoViewModel, CadastrarCentroDeCustoContaCorrenteCommand>()
                .ConstructUsing(cc => new CadastrarCentroDeCustoContaCorrenteCommand(cc.Descricao, cc.DataDeCadastro,cc.Ativo));

            CreateMap<CentroDeCustoViewModel, AtualizarCentroDeCustoContaCorrenteCommand>()
                .ConstructUsing(cc => new AtualizarCentroDeCustoContaCorrenteCommand(cc.Id, cc.Descricao));

            CreateMap<CentroDeCustoViewModel, ExcluirCentroDeCustoContaCorrenteCommand>()
                .ConstructUsing(cc => new ExcluirCentroDeCustoContaCorrenteCommand(cc.Id));

            CreateMap<ClienteViewModel, CadastrarClienteContaCorrenteCommand>()
                .ConstructUsing(c => new CadastrarClienteContaCorrenteCommand(c.Nome, c.CPF, c.Email, c.DataDeNascimento,
                                        c.DataDeCadastro, c.Ativo));

            CreateMap<ClienteViewModel, AtualizarClienteContaCorrenteCommand>()
                .ConstructUsing(c => new AtualizarClienteContaCorrenteCommand(c.Id, c.Nome, c.CPF, c.Email, c.DataDeNascimento));

            CreateMap<ClienteViewModel, ExcluirClienteContaCorrenteCommand>()
                .ConstructUsing(c => new ExcluirClienteContaCorrenteCommand(c.Id));

            CreateMap<ContaCorrenteViewModel, CadastrarContaCorrenteCommand>()
                .ConstructUsing(cc => new CadastrarContaCorrenteCommand(cc.NumeroDaContaCorrente, cc.AgenciaId, cc.ClienteId,
                                            cc.DataDeCadastro,cc.Ativo));

            CreateMap<ContaCorrenteViewModel, AtualizarContaCorrenteCommand>()
                .ConstructUsing(cc => new AtualizarContaCorrenteCommand(cc.Id, cc.NumeroDaContaCorrente, cc.AgenciaId,
                                        cc.ClienteId));

            CreateMap<ContaCorrenteViewModel, ExcluirContaCorrenteCommand>()
                .ConstructUsing(cc => new ExcluirContaCorrenteCommand(cc.Id));

            CreateMap<LancamentoViewModel, CadastrarLancamentoContaCorrenteCommand>()
                .ConstructUsing(l => new CadastrarLancamentoContaCorrenteCommand(
                                    l.Sequencial, l.Observacao, l.Valor, l.DataDoLancamento, l.Competencia,
                                    l.CentroDeCustoId, l.PlanoDeContaId, l.ContaCorrenteId, l.DataDeCadastro,l.Ativo));

            CreateMap<LancamentoViewModel, AtualizarLancamentoContaCorrenteCommand>()
                .ConstructUsing(l => new AtualizarLancamentoContaCorrenteCommand(
                                    l.Id, l.Sequencial, l.Observacao, l.Valor, l.DataDoLancamento, l.Competencia,
                                    l.CentroDeCustoId, l.PlanoDeContaId, l.ContaCorrenteId));

            CreateMap<LancamentoViewModel, ExcluirLancamentoContaCorrenteCommand>()
                .ConstructUsing(l => new ExcluirLancamentoContaCorrenteCommand(l.Id));
            #endregion
        }
    }
}
