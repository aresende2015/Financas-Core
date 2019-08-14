using Financas.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Repository
{
    public interface IAgenciaRepository : IRepository<Agencia>
    {
        IEnumerable<Agencia> ObterAgenciaPorBanco(Guid bancoId);

        Agencia ObterAgenciaPorNumero(int numeroDaAgencia);

        Agencia ObterAgenciaPorNome(string nomeDaAgencia);

        Endereco ObterEnderecoPorId(Guid enderecoId);

        void AdicionarEnderco(Endereco endereco);

        void AtualizarEnderco(Endereco endereco);

        IEnumerable<Cidade> ListarCidadesPorUF(string uf);

        Cidade ObterCidadePorId(Guid cidadeId);
    }
}
