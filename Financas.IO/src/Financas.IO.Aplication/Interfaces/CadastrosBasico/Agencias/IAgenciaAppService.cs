using Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias;
using System;
using System.Collections.Generic;

namespace Financas.IO.Aplication.Interfaces.CadastrosBasico.Agencias
{
    public interface IAgenciaAppService : IDisposable
    {
        void Cadastrar(AgenciaViewModel agenciaViewModel);

        void Atualizar(AgenciaViewModel agenciaViewModel);

        void Excluir(Guid id);

        IEnumerable<AgenciaViewModel> ObterTodos();

        IEnumerable<AgenciaViewModel> ObterAgenciaPorBanco(Guid bancoId);

        AgenciaViewModel ObterPorId(Guid id);

        AgenciaViewModel ObterAgenciaPorNumero(int numeroDaAgencia);

        AgenciaViewModel ObterAgenciaPorNome(string nomeDaAgencia);

        void IncluirEndereco(EnderecoViewModel enderecoViewModel);

        void AtualizarEndereco(EnderecoViewModel enderecoViewModel);

        EnderecoViewModel ObterEnderecoPorId(Guid id);

        IEnumerable<CidadeViewModel> ListarCidadesPorUF(string uf);

        CidadeViewModel ObterCidadePorId(Guid cidadeId);
    }
}
