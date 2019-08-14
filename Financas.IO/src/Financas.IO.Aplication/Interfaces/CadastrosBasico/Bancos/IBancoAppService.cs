using Financas.IO.Aplication.ViewModels.CadastrosBasico.Bancos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Financas.IO.Aplication.Interfaces.CadastrosBasico.Bancos
{
    public interface IBancoAppService : IDisposable
    {
        void Cadastrar(BancoViewModel bancoViewModel);

        void Atualizar(BancoViewModel bancoViewModel);

        void Excluir(Guid id);

        IEnumerable<BancoViewModel> ObterTodos();

        BancoViewModel ObterPorId(Guid id);
    }
}
