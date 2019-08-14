using Financas.IO.Domain.Core.Commands;
using System;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Commands
{
    public class IncluirEnderecoAgenciaCommand : Command    
    {
        public IncluirEnderecoAgenciaCommand(Guid id, string logradouro, string numero, string complemento, string bairro, 
                                             string cep, Guid cidadeId, Guid? agenciaId, DateTime dataDeCadastro, bool ativo)
        {
            Id = id;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            CidadeId = cidadeId;
            AgenciaId = agenciaId;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
        }

        public Guid Id { get; private set; }

        public string Logradouro { get; private set; }

        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Bairro { get; private set; }

        public string CEP { get; private set; }

        public Guid CidadeId { get; private set; }

        public Guid? AgenciaId { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public bool Ativo { get; private set; }
    }
}
