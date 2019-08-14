using AutoMapper;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Bancos;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.PlanosDeContas;
using Financas.IO.Aplication.ViewModels.GerenciarContaCorrente.ContasCorrente;
using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Domain.CadastrosBasico.Bancos;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas;
using Financas.IO.Domain.GerenciarContaCorrente.ContasCorrente;

namespace Financas.IO.Aplication.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Agencia, AgenciaViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Cidade, CidadeViewModel>();

            CreateMap<Banco, BancoViewModel>();

            CreateMap<PlanoDeConta, PlanoDeContaViewModel>();
            CreateMap<GrupoDeConta, GrupoDeContaViewModel>();

            CreateMap<CentroDeCusto, CentroDeCustoViewModel>();
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<ContaCorrente, ContaCorrenteViewModel>();
            CreateMap<Lancamento, LancamentoViewModel>();

           
        }
    }
}
