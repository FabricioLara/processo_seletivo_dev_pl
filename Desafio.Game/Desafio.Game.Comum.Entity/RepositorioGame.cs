using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Desafio.Game.Comum.Interfaces;
using System.Data.Entity;
using System.Linq;

namespace Desafio.Game.Comum.Entity
{
    public class RepositorioGame<TDominio, TChave> : IRepositorioGame<TDominio, TChave>
        where TDominio : class
    {

        protected DbContext _context;
        protected DbContextTransaction _transacao;

        public RepositorioGame(DbContext contexto)
        {
            _context = contexto;
            _transacao = _context.Database.BeginTransaction();
        }

        public List<TDominio> Selecionar(Expression<Func<TDominio, bool>> where = null)
        {
            try
            {
                DbSet<TDominio> dbSetDominio = _context.Set<TDominio>();

                if (where == null)
                    return dbSetDominio.ToList();
                else
                    return dbSetDominio.Where(where).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public TDominio SelecionarPorID(TChave id)
        {
            try
            {
                return _context.Set<TDominio>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Inserir(TDominio dominio)
        {
            try
            {
                _context.Set<TDominio>().Add(dominio);
                _context.SaveChanges();
                _transacao.Commit();
            }
            catch (Exception)
            {
                _transacao.Rollback();
                throw;
            }
        }

        public void Atualizar(TDominio dominio)
        {
            try
            {
                _context.Entry(dominio).State = EntityState.Modified;
                _context.SaveChanges();
                _transacao.Commit();
            }
            catch (Exception)
            {
                _transacao.Rollback();
                throw;
            }
        }

        public void AtualizarPorId(TChave id)
        {
            TDominio dominio = SelecionarPorID(id);
            Atualizar(dominio);
        }

        public void Excluir(TDominio dominio)
        {
            try
            {
                _context.Entry(dominio).State = EntityState.Deleted;
                _context.SaveChanges();
                _transacao.Commit();
            }
            catch (Exception)
            {
                _transacao.Rollback();
                throw;
            }
           
        }

        public void ExcluirPorId(TChave id)
        {
            TDominio dominio = SelecionarPorID(id);
            Excluir(dominio);
        }
    }
}
