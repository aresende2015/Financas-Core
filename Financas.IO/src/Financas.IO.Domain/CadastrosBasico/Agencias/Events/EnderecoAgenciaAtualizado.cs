using Financas.IO.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.Agencias.Events
{
    public class EnderecoAgenciaAtualizadoEvent: Event
    {
        public Guid Id { get; private set; }

        public string Logradouro { get; private set; }

        public string Numero { get; private set; }

        public string Complemento { get; private set; }

        public string Bairro { get; private set; }

        public string CEP { get; private set; }

        public Guid CidadeId { get; private set; }

        public DateTime DataDeCadastro { get; private set; }

        public bool Ativo { get; private set; }

        public EnderecoAgenciaAtualizadoEvent(Guid enderecoId, string logradouro, string numero,
                                            string complemento, string bairro, string cep,
                                            Guid cidadeId, DateTime dataDeCadastro, bool ativo,
                                            Guid agenciaId)
        {
            Id = enderecoId;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            CidadeId = cidadeId;
            DataDeCadastro = dataDeCadastro;
            Ativo = ativo;
            AggregateId = agenciaId;
        }
    }
}
