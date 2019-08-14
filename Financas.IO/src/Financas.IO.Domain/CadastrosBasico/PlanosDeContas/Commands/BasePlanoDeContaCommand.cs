using Financas.IO.Domain.Core.Commands;
using Financas.IO.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Domain.CadastrosBasico.PlanosDeContas.Commands
{
    public class BasePlanoDeContaCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Descricao { get; protected set; }

        public TipoDeMovimentacao TipoDeMovimento { get; protected set; }

        public DateTime DataDeCadastro { get; protected set; }

        public bool Ativo { get; protected set; }

        public Guid GrupoDeContaId { get; protected set; }
    }
}
