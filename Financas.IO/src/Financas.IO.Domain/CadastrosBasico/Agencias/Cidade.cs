using Financas.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Financas.IO.Domain.CadastrosBasico.Agencias
{
    public class Cidade : Entity<Cidade>
    {
        public int CodigoIBGE { get; private set; }

        public string Descricao { get; private set; }

        public string UF { get; private set; }

        public bool IsCapital { get; private set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }

        public Cidade(
            int codigoIBGE,
            string uf,
            bool isCapital,
            string descricao)
        {
            Id = Guid.NewGuid();
            CodigoIBGE = codigoIBGE;
            UF = uf;
            IsCapital = isCapital;
            Descricao = descricao;
            DataDeCadastro = DateTime.Now;
            Ativo = true;

        }

        // Construtor para o EF
        protected Cidade()
        {

        }

        public override bool EhValido()
        {
            return true;
        }
    }
}