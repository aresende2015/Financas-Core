using Financas.IO.Domain.CadastrosBasico.PlanosDeContas;
using Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Repositoy;
using Financas.IO.Infra.Data2.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Financas.IO.Infra.Data2.Repository.CadastrosBasico.PlanosDeContas
{
    public class PlanoDeContaRepository : Repository<PlanoDeConta>, IPlanoDeContaRepository
    {
        public PlanoDeContaRepository(FinancaEFContext context) : base(context)
        {

        }

        public override PlanoDeConta ObterPorId(Guid id)
        {
            return Db.PlanoDeContas.Include(pc => pc.GrupoDeConta).FirstOrDefault(pc => pc.Id == id);
        }

        public void AdicionarGrupoDeConta(GrupoDeConta grupoDeConta)
        {
            Db.GrupoDeContas.Add(grupoDeConta);
        }

        public void AtualizarGrupoDeConta(GrupoDeConta grupoDeConta)
        {
            Db.GrupoDeContas.Update(grupoDeConta);
        }

        public GrupoDeConta ObterGrupoDeContaPorId(Guid grupoDeContaId)
        {
            return Db.GrupoDeContas.Find(grupoDeContaId);
        }

        public IEnumerable<GrupoDeConta> ObterTodosGrupoDeConta()
        {
            return Db.GrupoDeContas.ToList();
        }

        public IEnumerable<PlanoDeConta> ObterPlanoDecontaPorGrupoDeConta(Guid grupoDeContaId)
        {
            return Db.PlanoDeContas.Where(pc => pc.GrupoDeContaId == grupoDeContaId);
        }

    }
}
