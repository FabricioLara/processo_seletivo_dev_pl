using Desafio.Game.Comum.Interfaces;
using Desafio.Game.Core.DataContexts;
using Desafio.Game.Core.Repositorios;
using Desafio.Game.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Desafio.Game.Web.Controllers
{
    public class HomeController : Controller 
    {
        private IRepositorioGame<Jogo, int> _repositorioJogo
            = new RepositorioJogo(new GameDataContext());

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarJogos()
        {
            try
            {
                List<Jogo> listaJogos = _repositorioJogo.Selecionar().OrderByDescending(j => j.Id).ToList();
                return Json(listaJogos, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult CadastrarJogo(Jogo jogo)
        {
            try
            {
                _repositorioJogo.Inserir(jogo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult AtualizarJogo(Jogo jogo)
        {
            try
            {
                _repositorioJogo.Atualizar(jogo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult ExcluirJogo(int id)
        {
            try
            {
                _repositorioJogo.ExcluirPorId(id);
                 return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult Pesquisar(string titulo, string fornecedor)
        {
            try
            {
                List<Jogo> listaPesquisa = new List<Jogo>();

                if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(fornecedor))
                    listaPesquisa = _repositorioJogo.Selecionar(a => a.Titulo.Contains(titulo) && a.Fornecedor.Contains(fornecedor)).OrderByDescending(j => j.Id).ToList();

                else if(!string.IsNullOrEmpty(titulo) && string.IsNullOrEmpty(fornecedor))
                    listaPesquisa = _repositorioJogo.Selecionar(a => a.Titulo.Contains(titulo)).OrderByDescending(j => j.Id).ToList();

                else if(string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(fornecedor))
                    listaPesquisa = _repositorioJogo.Selecionar(a => a.Fornecedor.Contains(fornecedor)).OrderByDescending(j => j.Id).ToList();
                else
                    listaPesquisa = _repositorioJogo.Selecionar().OrderByDescending(j => j.Id).ToList();


                return Json(listaPesquisa, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

       
    }
}