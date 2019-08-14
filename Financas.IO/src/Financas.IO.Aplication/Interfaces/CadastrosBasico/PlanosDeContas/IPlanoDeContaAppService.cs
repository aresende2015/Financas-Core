using Financas.IO.Aplication.ViewModels.CadastrosBasico.PlanosDeContas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Aplication.Interfaces.CadastrosBasico.PlanosDeContas
{
    public interface IPlanoDeContaAppService : IDisposable
    {
        void Cadastrar(PlanoDeContaViewModel planoDeContaViewModel);

        void Atualizar(PlanoDeContaViewModel planoDeContaViewModel);

        void Excluir(Guid id);

        IEnumerable<PlanoDeContaViewModel> ObterTodos();

        IEnumerable<PlanoDeContaViewModel> ObterPlanoDecontaPorGrupoDeConta(Guid grupoDeContaId);

        PlanoDeContaViewModel ObterPorId(Guid id);

        void CadastrarGrupoDeConta(GrupoDeContaViewModel grupoDeContaViewModel);

        void AtualizarGrupoDeConta(GrupoDeContaViewModel grupoDeContaViewModel);

        void ExcluirGrupoDeConta(Guid grupoDeContaId);

        GrupoDeContaViewModel ObterGrupoDeContaPorId(Guid id);

        IEnumerable<GrupoDeContaViewModel> ObterTodosGrupoDeConta();
    }
}
