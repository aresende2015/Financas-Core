using Financas.IO.Aplication.Interfaces.CadastrosBasico.Bancos;
using Financas.IO.Aplication.ViewModels.CadastrosBasico.Bancos;
using Financas.IO.Domain.Core.Notifications;
using Financas.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;


namespace Financas.IO.Presentation.Site.Controllers.CadastrosBasico
{
    public class BancoController : BaseController
    {
        private readonly IBancoAppService _bancoAppService;

        public BancoController(IBancoAppService bancoAppService,
                               IDomainNotificationHandler<DomainNotification> notifications,
                               IUser user)
            : base(notifications, user)
        {
            _bancoAppService = bancoAppService;
        }

        public IActionResult Index()
        {
            return View(_bancoAppService.ObterTodos());
        }

        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancoViewModel = _bancoAppService.ObterPorId(id.Value);

            if (bancoViewModel == null)
            {
                return NotFound();
            }

            return View(bancoViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BancoViewModel bancoViewModel)
        {
            if (!ModelState.IsValid) return View(bancoViewModel);

            _bancoAppService.Cadastrar(bancoViewModel);

            ViewBag.RetornoPost = OperacaoValida() 
                    ? "success,Banco registrado com sucesso!" 
                    : "error,Banco não registrado! Verifique as mensagens";

            return View(bancoViewModel);
        }

        [Authorize]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancoViewModel = _bancoAppService.ObterPorId(id.Value);

            if (bancoViewModel == null)
            {
                return NotFound();
            }

            return View(bancoViewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BancoViewModel bancoViewModel)
        {
            if (!ModelState.IsValid) return View(bancoViewModel);

            _bancoAppService.Atualizar(bancoViewModel);

            // TODO: Validar se a operação ocorreu com sucesso!

            return View(bancoViewModel);
        }

        [Authorize]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bancoViewModel = _bancoAppService.ObterPorId(id.Value);

            if (bancoViewModel == null)
            {
                return NotFound();
            }

            return View(bancoViewModel);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bancoAppService.Excluir(id);

            return RedirectToAction("Index");
        }
    }
}
