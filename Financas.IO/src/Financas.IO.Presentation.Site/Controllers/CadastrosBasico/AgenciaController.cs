using Financas.IO.Aplication.Interfaces.CadastrosBasico.Agencias;
using Financas.IO.Aplication.Interfaces.CadastrosBasico.Bancos;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Agencias;
using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.Interfaces;
using Financas.IO.Presentation.Site.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;

namespace Financas.IO.Presentation.Site.Controllers.CadastrosBasico
{
    public class AgenciaController : BaseController
    {
        private readonly IAgenciaAppService _agenciaAppService;
        private readonly IBancoAppService _bancoAppService;

        public AgenciaController(IAgenciaAppService agenciaAppService,
                                 IBancoAppService bancoAppService,
                                IDomainNotificationHandler<DomainNotification> notifications,
                                IUser user)
            : base(notifications, user)
        {
            _agenciaAppService = agenciaAppService;
            _bancoAppService = bancoAppService;
        }

        public IActionResult Index()
        {
            return View(_agenciaAppService.ObterTodos());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciaViewModel = _agenciaAppService.ObterPorId(id.Value);

            if (agenciaViewModel == null)
            {
                return NotFound();
            }

            return View(agenciaViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var agenciaViewModel = new AgenciaViewModel();
            PreencherComboDeBanco(Guid.Empty);
            PreencherCidade(Guid.Empty, null);
            return View(agenciaViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AgenciaViewModel agenciaViewModel)
        {
            if (!ModelState.IsValid) return View(agenciaViewModel);

            _agenciaAppService.Cadastrar(agenciaViewModel);

            ViewBag.RetornoPost = OperacaoValida()
                    ? "success,Agência registrada com sucesso!"
                    : "error,Agência não registrada! Verifique as mensagens";

            PreencherComboDeBanco(agenciaViewModel.BancoId);

            var cidade = _agenciaAppService.ObterCidadePorId(agenciaViewModel.Endereco.CidadeId);

            PreencherCidade(cidade.Id, cidade.Descricao);

            return View(agenciaViewModel);
        }

        [Authorize]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciaViewModel = _agenciaAppService.ObterPorId(id.Value);

            if (agenciaViewModel == null)
            {
                return NotFound();
            }

            PreencherComboDeBanco(agenciaViewModel.BancoId);
            PreencherCidade(agenciaViewModel.Endereco.Cidade.Id, agenciaViewModel.Endereco.Cidade.Descricao);

            return View(agenciaViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AgenciaViewModel agenciaViewModel)
        {
            if (!ModelState.IsValid) return View(agenciaViewModel);

            _agenciaAppService.Atualizar(agenciaViewModel);

            // TODO: Validar se a operação ocorreu com sucesso!

            return View(agenciaViewModel);
        }

        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenciaViewModel = _agenciaAppService.ObterPorId(id.Value);

            if (agenciaViewModel == null)
            {
                return NotFound();
            }

            return View(agenciaViewModel);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _agenciaAppService.Excluir(id);

            return RedirectToAction("Index");
        }

        [Authorize]
        [Route("incluir-endereco/{id:guid}")]
        public IActionResult IncluirEndereco(Guid id)
        {
            if (id == null)
                return NotFound();

            var agenciaViewModel = _agenciaAppService.ObterPorId(id);

            return PartialView("_IncluirEndereco", agenciaViewModel);
        }

        [Authorize]
        [Route("atualizar-endereco/{id:guid}")]
        public IActionResult AtualizarEndereco(Guid id)
        {
            if (id == null)
                return NotFound();

            var agenciaViewModel = _agenciaAppService.ObterPorId(id);

            return PartialView("_AtualizarEndereco", agenciaViewModel);
        }

        [Authorize]
        [HttpPost]
        [Route("incluir-endereco/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult IncluirEndereco(AgenciaViewModel agenciaViewModel)
        {
            agenciaViewModel.Endereco.AgenciaId = agenciaViewModel.Id;

           // _agenciaAppService.IncluirEndereco(agenciaViewModel.Endereco);

            if(OperacaoValida())
            {
                var url = Url.Action("ObterEndereco", "Agencia", new { id = agenciaViewModel.Id });

                return Json(new { success = true, url = url });
            }

            return PartialView("_IncluirEndereco", agenciaViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("atualizar-endereco/{id:guid}")]
        public IActionResult AtualziarEndereco(AgenciaViewModel agenciaViewModel)
        {
            _agenciaAppService.AtualizarEndereco(agenciaViewModel.Endereco);

            if (OperacaoValida())
            {
                var url = Url.Action("ObterEndereco", "Agencia", new { id = agenciaViewModel.Id });

                return Json(new { success = true, url = url });
            }

            return PartialView("_AtualizarEndereco", agenciaViewModel);
        }

        public IActionResult ObterEndereco(Guid id)
        {
            return PartialView("_DetalhesEndereco", _agenciaAppService.ObterPorId(id));
        }

        private void PreencherComboDeBanco(Guid bancoId)
        {
            if (bancoId == Guid.Empty)
            {
                ViewBag.BancoId = new SelectList(_bancoAppService.ObterTodos(), "Id", "Descricao");
            }
            else
            {
                ViewBag.BancoId = new SelectList(_bancoAppService.ObterTodos(), "Id", "Descricao", bancoId);
            }

        }

        private void PreencherCidade(Guid cidadeId, string descricao)
        {
            ViewBag.CidadeId = cidadeId;
            ViewBag.CidadeDescricao = descricao;
        }

        [Authorize]
        public JsonResult ListarCidadesUF(string uf, string term)
        {
            var cidadesPorUFFiltradas = _agenciaAppService
                                        .ListarCidadesPorUF(uf)
                                        .Where(c => c.Descricao.RemoveAccents().ToUpper().StartsWith(term.RemoveAccents().ToUpper()))
                                        .Select(c => new { Id = c.Id, Nome = c.Descricao });

            return Json(cidadesPorUFFiltradas);
        }

        
    }

}
