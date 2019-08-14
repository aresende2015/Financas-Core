using Dapper;
using Financas.IO.Domain.CadastrosBasico.Agencias;
using Financas.IO.Domain.CadastrosBasico.Agencias.Repository;
using Financas.IO.Domain.CadastrosBasico.Bancos;
using Financas.IO.Infra.Data2.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Financas.IO.Infra.Data2.Repository.CadastrosBasico.Agencias
{
    public class AgenciaRepository : Repository<Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(FinancaEFContext context) : base(context)
        {
            
        }

        public void AdicionarEnderco(Endereco endereco)
        {
            Db.Enderecos.Add(endereco);
        }

        public void AtualizarEnderco(Endereco endereco)
        {
            Db.Enderecos.Update(endereco);
        }

        public IEnumerable<Agencia> ObterAgenciaPorBanco(Guid bancoId)
        {
            var sql = @"SELECT * FROM Agencias A " +
                      "WHERE A.BancoId = @uid " +
                      "ORDER BY A.NumeroDaAgencia";

            return Db.Database.GetDbConnection().Query<Agencia>
                            (sql, new { uid = bancoId });

            //return Db.Agencias.Where(a => a.BancoId == bancoId);
        }

        public Endereco ObterEnderecoPorId(Guid enderecoId)
        {
            var sql = @"SELECT * FROM Enderecos E " +
                      "WHERE E.Id = @uid";

            var endereco = Db.Database.GetDbConnection().Query<Endereco>
                            (sql, new { uid = enderecoId });

            return endereco.SingleOrDefault();

            //return Db.Enderecos.Find(enderecoId);
        }

        public override Agencia ObterPorId(Guid id)
        {
            var sql = @"SELECT * " + 
                       "FROM Agencias A " +
                       "   LEFT JOIN Bancos B " +
                       "      ON B.Id = A.BancoId " +
                       "   LEFT JOIN Enderecos E " +
                       "      ON A.Id = E.AgenciaId " +
                       "   LEFT JOIN Cidades C " +
                       "      ON C.Id = E.CidadeId " +
                       "WHERE A.Id = @uid";

            var agencia = Db.Database.GetDbConnection().Query<Agencia, Banco, Endereco, Cidade, Agencia>
                            (sql, (a, b, e, c) =>
                            {
                                if (b != null)
                                    a.AtribuirBanco(b);

                                if (e != null)
                                    a.AtribuirEnderco(e);

                                if (c != null)
                                {
                                    a.Endereco.AtribuirCidade(c);
                                }                                    

                                return a;
                            }, new {uid = id}
                            );

            return agencia.FirstOrDefault();

            //return Db.Agencias.Include(a => a.Endereco).FirstOrDefault(a => a.Id == id);
        }

        public override IEnumerable<Agencia> ObterTodos()
        {
            //var sql = @"SELECT * FROM Agencias A ORDER BY A.BancoId, A.NumeroDaAgencia";

            //return Db.Database.GetDbConnection().Query<Agencia>(sql);

            var sql = @"SELECT * " +
                       "FROM Agencias A " +
                       "   LEFT JOIN Bancos B " +
                       "      ON B.Id = A.BancoId " +
                       "ORDER BY B.Descricao, A.NumeroDaAgencia";

            var agencias = Db.Database.GetDbConnection().Query<Agencia, Banco, Agencia>
                            (sql, (a, b) =>
                            {
                                if (b != null)
                                    a.AtribuirBanco(b);

                                return a;
                            }
                            );

            return agencias.ToList();

        }

        public Agencia ObterAgenciaPorNumero(int numeroDaAgencia)
        {
            var sql = @"SELECT * FROM Agencias A WHERE A.NumeroDaAgencia = @unumeroDaAgencia";

            var agencia = Db.Database.GetDbConnection().Query<Agencia>
                            (sql, new { unumeroDaAgencia = numeroDaAgencia }
                            );

            return agencia.FirstOrDefault();
        }

        public Agencia ObterAgenciaPorNome(string nomeDaAgencia)
        {
            var sql = @"SELECT * FROM Agencias A WHERE A.NomeDaAgencia = @unomeDaAgencia";

            var agencia = Db.Database.GetDbConnection().Query<Agencia>
                            (sql, new { unomeDaAgencia = nomeDaAgencia }
                            );

            return agencia.FirstOrDefault();
        }

        public IEnumerable<Cidade> ListarCidadesPorUF(string UF)
        {
            var sql = @"SELECT * FROM Cidades C WHERE C.UF = @uUF ORDER BY C.Descricao";

            return Db.Database.GetDbConnection().Query<Cidade>
                            (sql, new { uUF = UF });           
        }

        public Cidade ObterCidadePorId(Guid cidadeId)
        {
            var sql = @"SELECT * FROM Cidades C " +
                      "WHERE C.Id = @uid";

            var cidade = Db.Database.GetDbConnection().Query<Cidade>
                            (sql, new { uid = cidadeId });

            return cidade.SingleOrDefault();
        }

    }
}
