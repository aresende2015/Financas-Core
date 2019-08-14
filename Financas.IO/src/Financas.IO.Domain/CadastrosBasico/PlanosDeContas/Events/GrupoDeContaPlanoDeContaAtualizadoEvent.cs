﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Events
{
    public class GrupoDeContaPlanoDeContaAtualizadoEvent : BaseGrupoDeContaPlanoDeContaEvent
    {
        public GrupoDeContaPlanoDeContaAtualizadoEvent(
                    Guid id,
                    string descricao,
                    DateTime dataDeCadastro)
        {
            Id = id;
            Descricao = descricao;
            DataDeCadastro = dataDeCadastro;

            AggregateId = id;
        }
    }
}
