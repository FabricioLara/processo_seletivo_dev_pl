using Desafio.Game.Comum.Entity;
using Desafio.Game.Core.DataContexts;
using Desafio.Game.Dominio;

namespace Desafio.Game.Core.Repositorios
{
    public class RepositorioJogo : RepositorioGame<Jogo, int>
    {
        public RepositorioJogo(GameDataContext contexto)
            :base(contexto)
        {

        }
    }
}
