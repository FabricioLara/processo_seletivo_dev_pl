using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Desafio.Game.Core.DataContexts;
using Desafio.Game.Dominio;
using Desafio.Game.Comum.Interfaces;
using Desafio.Game.Core.Repositorios;
using System;
using System.Collections.Generic;
using Desafio.Game.Web.ViewModel;
using Desafio.Game.Web.AutoMapper;

namespace Desafio.Game.Web.Controllers
{
    public class JogosController : Controller
    {

        private IRepositorioGame<Jogo, int> _repositorioJogo =
            new RepositorioJogo(new GameDataContext());

        public ActionResult Index()
        {
            try
            {
                List<Jogo> lista = _repositorioJogo.Selecionar().OrderByDescending(j => j.Id).ToList();
                List<JogoIndexViewModel> listaViewModel = AutoMapperManager.Instance.Mapper.Map<List<Jogo>, List<JogoIndexViewModel>>(lista);

                return View(listaViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public ActionResult Consulta(int? codigo, string genero, string fornecedor)
        {

            List<Jogo> listaJogos = new List<Jogo>();
           
            if (codigo.HasValue && string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(fornecedor))
                listaJogos = _repositorioJogo.Selecionar(a => a.Id == codigo.Value).OrderByDescending(j => j.Id).ToList();
            else if(!codigo.HasValue && !string.IsNullOrEmpty(genero) && string.IsNullOrEmpty(fornecedor))
                listaJogos = _repositorioJogo.Selecionar(a => a.Genero.Contains(genero)).OrderByDescending(j => j.Id).ToList();
            else if (!codigo.HasValue && string.IsNullOrEmpty(genero) && !string.IsNullOrEmpty(fornecedor))
                listaJogos = _repositorioJogo.Selecionar(a => a.Fornecedor.Contains(fornecedor)).OrderByDescending(j => j.Id).ToList();
            else
                listaJogos = _repositorioJogo.Selecionar().OrderByDescending(j => j.Id).ToList();

     
            return View("Consulta", listaJogos);
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Jogo jogo = _repositorioJogo.SelecionarPorID(id.Value);

                if (jogo == null)
                {
                    return HttpNotFound();
                }

                return View(AutoMapperManager.Instance.Mapper.Map<Jogo, JogoIndexViewModel>(jogo));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Genero,Plataforma,Fornecedor,Descricao,Link,DataAdquirida")] JogoViewModel jogoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    Jogo jogo = AutoMapperManager.Instance.Mapper.Map<JogoViewModel, Jogo>(jogoViewModel);
                    _repositorioJogo.Inserir(jogo);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return View(jogoViewModel);
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Jogo jogo = _repositorioJogo.SelecionarPorID(id.Value);

                if (jogo == null)
                {
                    return HttpNotFound();
                }

                return View(AutoMapperManager.Instance.Mapper.Map<Jogo, JogoViewModel>(jogo));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Genero,Plataforma,Fornecedor,Descricao,Link,DataAdquirida")] JogoViewModel jogoViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Jogo jogo = AutoMapperManager.Instance.Mapper.Map<JogoViewModel, Jogo>(jogoViewModel);
                    _repositorioJogo.Atualizar(jogo);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return View(jogoViewModel);
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Jogo jogo = _repositorioJogo.SelecionarPorID(id.Value);
                if (jogo == null)
                {
                    return HttpNotFound();
                }
                return View(AutoMapperManager.Instance.Mapper.Map<Jogo, JogoIndexViewModel>(jogo));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

    }
}
