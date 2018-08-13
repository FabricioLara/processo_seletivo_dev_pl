using Desafio.Game.Dominio;
using System.Data.Entity.ModelConfiguration;

namespace Desafio.Game.Core.Mappin
{
    public class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {
            ToTable("Jogo");

            HasKey(j => j.Id);

            Property(j => j.Titulo).HasMaxLength(100).IsRequired();
            Property(j => j.Genero).HasMaxLength(60).IsRequired();
            Property(j => j.Plataforma).HasMaxLength(60).IsRequired();
            Property(j => j.Fornecedor).HasMaxLength(100).IsRequired();
            Property(j => j.Descricao).HasMaxLength(255).IsRequired();
            Property(j => j.Link).HasMaxLength(80).IsOptional();
        }
    }
}
