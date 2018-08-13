using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Desafio.Game.Comum.Interfaces
{
   public interface IRepositorioGame<TDominio, TChave>
        where TDominio : class
    {
        List<TDominio> Selecionar(Expression<Func<TDominio, bool>> where = null);

        TDominio SelecionarPorID(TChave id);

        void Inserir(TDominio dominio);

        void Atualizar(TDominio dominio);

        void AtualizarPorId(TChave id);

        void Excluir(TDominio dominio);

        void ExcluirPorId(TChave id);
    }
}
