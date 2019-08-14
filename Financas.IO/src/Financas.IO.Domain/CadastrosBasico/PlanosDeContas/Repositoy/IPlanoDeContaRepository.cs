using Financas.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Repositoy
{
    public interface IPlanoDeContaRepository : IRepository<PlanoDeConta>
    {
        IEnumerable<PlanoDeConta> ObterPlanoDecontaPorGrupoDeConta(Guid GrupoDeContaId);       

        GrupoDeConta ObterGrupoDeContaPorId(Guid grupoDeContaId);

        IEnumerable<GrupoDeConta> ObterTodosGrupoDeConta();

        void AdicionarGrupoDeConta(GrupoDeConta grupoDeConta);

        void AtualizarGrupoDeConta(GrupoDeConta grupoDeConta);
    }
}
