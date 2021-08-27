using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TesteBNP.Negocios.Entidades;
using TesteBNP.Negocios.Enumeradores;
using TesteBNP.Negocios.Interfaces.Servicos;
using TesteBNP.Site.Models;

namespace TesteBNP.Site.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(
            IMovimentoManualServico manualServico,
            IProdutoCosifServico cosifServico,
            IProdutoServico produtoServico)
        {
            _manualServico = manualServico;
            _cosifServico = cosifServico;
            _produtoServico = produtoServico;
        }

        private IMovimentoManualServico _manualServico;
        private IProdutoCosifServico _cosifServico;
        private IProdutoServico _produtoServico;

        public IActionResult Index()
        {
            MovimentoManualViewModel model = new MovimentoManualViewModel();
            model.MovimentosManuais = _manualServico.ObterTodos();
            model.ProdutosCosif = _cosifServico.ObterTodos();
            model.Produtos = _produtoServico.ObterTodos();

            return View(model);
        }

        public IActionResult IncluirMovimentoManual(MovimentoManualViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.MovimentosManuais = _manualServico.ObterTodos();
                model.ProdutosCosif = _cosifServico.ObterTodos();
                model.Produtos = _produtoServico.ObterTodos();

                return View("Index", model);
            }

            _manualServico.Inserir(model.MovimentoManual);
            model.MovimentosManuais = _manualServico.ObterTodos();
            model.ProdutosCosif = _cosifServico.ObterTodos();
            model.Produtos = _produtoServico.ObterTodos();
            model.MovimentoManual = new MovimentoManual();

            return View("Index", model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
