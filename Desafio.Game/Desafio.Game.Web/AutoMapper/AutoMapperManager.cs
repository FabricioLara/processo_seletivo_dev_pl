using AutoMapper;
using Desafio.Game.Dominio;
using Desafio.Game.Web.ViewModel;
using System;

namespace Desafio.Game.Web.AutoMapper
{
    public class AutoMapperManager
    {
        private static readonly Lazy<AutoMapperManager> _instance =
            new Lazy<AutoMapperManager>(() => {
                return new AutoMapperManager();
            });

        public static AutoMapperManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        private MapperConfiguration _config;

        public IMapper Mapper
        {
            get
            {
                return _config.CreateMapper();
            }
        }

        private AutoMapperManager()
        {
            _config = new MapperConfiguration((cfg) =>
            {
                cfg.CreateMap<Jogo, JogoIndexViewModel>();
                cfg.CreateMap<JogoIndexViewModel, Jogo>();
            });
        }
    }
}