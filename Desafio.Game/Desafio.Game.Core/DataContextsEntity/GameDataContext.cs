using Desafio.Game.Core.Mappin;
using Desafio.Game.Dominio;
using System.Data.Entity;

namespace Desafio.Game.Core.DataContexts
{
    public class GameDataContext : DbContext
    {
        public GameDataContext()
            : base("GameDataContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Database.SetInitializer(new GameDataContextInitializer());
        }

        public DbSet<Jogo> Jogos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new JogoMap());
            base.OnModelCreating(modelBuilder);
        }

        private class GameDataContextInitializer : CreateDatabaseIfNotExists<GameDataContext>
        {
            protected override void Seed(GameDataContext context)
            {
                context.Jogos.Add(new Jogo() { Titulo = "Call of Duty", Genero = "Ação", Plataforma = "Xbob 360", Fornecedor = "Moovi Tecnologia em Softwares", Descricao = "sinopse do jogo Call of Duty", Link = "Xbox Live" });
                context.Jogos.Add(new Jogo() { Titulo = "Counter Strike", Genero = "Ação", Plataforma = "PC", Fornecedor = "MegaGames", Descricao = "sinopse do jogo Counter Strike", Link = "TechTudo" });
                context.Jogos.Add(new Jogo() { Titulo = "FIFA 2018", Genero = "Esporte", Plataforma = "Xbob 360", Fornecedor = "Sony Store", Descricao = "sinopse do jogo FIFA 2018", Link = "Xbox Live" });
                context.Jogos.Add(new Jogo() { Titulo = "NFL Head Coach", Genero = "Esporte", Plataforma = "PlayStation 4", Fornecedor = "Tidal Games", Descricao = "sinopse do jogo NFL Head Coach", Link = "Tidal Games" });
                context.Jogos.Add(new Jogo() { Titulo = "Down of War", Genero = "Estrategia", Plataforma = "PlayStation 4", Fornecedor = "Tidal Games", Descricao = "sinopse do jogo Down of War", Link = "PlayStationOficial" });
                context.Jogos.Add(new Jogo() { Titulo = "Prince of Persia", Genero = "Aventura", Plataforma = "PlayStation 3", Fornecedor = "Nintendo Game", Descricao = "sinopse do jogo Prince of Persia", Link = "PlayStationOficial" });
                context.Jogos.Add(new Jogo() { Titulo = "Tomb Raider", Genero = "Aventura", Plataforma = "Xbox 360", Fornecedor = "Warner-Games", Descricao = "sinopse do jogo Tomb Raider", Link = "Xbox Live" });
                context.Jogos.Add(new Jogo() { Titulo = "Cute Dog Jigsaw", Genero = "Quebra Cabeça", Plataforma = "Tablets", Fornecedor = "Sony Store", Descricao = "sinopse do jogo Cute Dog Jigsaw", Link = "Wallmart" });
                context.Jogos.Add(new Jogo() { Titulo = "Simon e Rock Band", Genero = "Música", Plataforma = "PC", Fornecedor = "EA Distribution", Descricao = "sinopse do jogo Simon e Rock Band", Link = "Techmania" });

                context.SaveChanges();

                base.Seed(context);
            }
        }
    }
}
