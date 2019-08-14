using System.Collections.Generic;
using Financas.IO.Domain.CadastrosBasico.Bancos;
using Financas.IO.Domain.CadastrosBasico.Bancos.Repository;
using Financas.IO.Infra.Data2.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Financas.IO.Infra.Data2.Repository.CadastrosBasico.Agencias
{
    public class BancoRepository : Repository<Banco>, IBancoRepository
    {
        public BancoRepository(FinancaEFContext context) : base(context)
        {
            
        }

        public override IEnumerable<Banco> ObterTodos()
        {
            var sql = @"SELECT * FROM BANCOS B ORDER BY B.DESCRICAO";

            return Db.Database.GetDbConnection().Query<Banco>(sql);
        }

        public override Banco ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Bancos B " +
                      "WHERE B.Id = @uid";

            var banco = Db.Database.GetDbConnection().Query<Banco>
                            (sql, new { uid = id });

            return banco.SingleOrDefault();
        }
    }
}
