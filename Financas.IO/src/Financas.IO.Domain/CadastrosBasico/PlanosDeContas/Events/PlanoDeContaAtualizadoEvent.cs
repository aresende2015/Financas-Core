using Financas.IO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Events
{
    public class PlanoDeContaAtualizadoEvent : BasePlanoDeContaEvent
    {
        public PlanoDeContaAtualizadoEvent(
                    Guid id, 
                    string descricao, 
                    TipoDeMovimentacao tipoDeMovimento, 
                    DateTime dataDeCadastro)
        {
            Id = id;
            Descricao = descricao;
            TipoDeMovimento = tipoDeMovimento;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;
        }
    }
}
