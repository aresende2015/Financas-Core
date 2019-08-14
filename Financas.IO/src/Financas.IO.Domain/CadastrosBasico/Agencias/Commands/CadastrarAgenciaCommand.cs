using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Commands
{
    public class CadastrarAgenciaCommand : BaseAgenciaCommand
    {
        public CadastrarAgenciaCommand(
            int numeroDaAgencia, 
            string nomeDaAgencia,
            Guid bancoId,
            DateTime dataDeCadastro,
            bool ativo,
            IncluirEnderecoAgenciaCommand endereco)
        {
            NumeroDaAgencia = numeroDaAgencia;
            NomeDaAgencia = nomeDaAgencia;
            BancoId = bancoId;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
            Endereco = endereco;
        }

        public IncluirEnderecoAgenciaCommand Endereco { get; private set; }
    }
}
