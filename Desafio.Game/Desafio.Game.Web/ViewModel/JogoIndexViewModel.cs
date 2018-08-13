using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio.Game.Web.ViewModel
{
    public class JogoIndexViewModel
    {
        [Display(Name = "Código:")]
        public int Id { get; set; }

        [Display(Name = "Título:")]
        public string Titulo { get; set; }

        [Display(Name = "Gênero:")]
        public string Genero { get; set; }

        [Display(Name = "Plataforma:")]
        public string Plataforma { get; set; }

        [Display(Name = "Fornecedor:")]
        public string Fornecedor { get; set; }

        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }

        [Display(Name = "Link:")]
        public string Link { get; set; }
    }
}