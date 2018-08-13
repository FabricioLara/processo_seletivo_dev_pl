using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio.Game.Web.ViewModel
{
    public class JogoViewModel
    {

        [Display(Name = "Código:")]
        [Required(ErrorMessage = "O ID do jogo é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Título:")]
        [Required(ErrorMessage = "O Título do jogo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O título do jogo pode ter no máximo 100 caracteres." )]
        public string Titulo { get; set; }

        [Display(Name = "Gênero:")]
        [Required(ErrorMessage = "O Gênero do jogo é obrigatório.")]
        [MaxLength(60, ErrorMessage = "O gênero do jogo pode ter no máximo 60 caracteres.")]
        public string Genero { get; set; }

        [Display(Name = "Plataforma:")]
        [Required(ErrorMessage = "A Plataforma do jogo é obrigatório.")]
        [MaxLength(60, ErrorMessage = "A plataforma do jogo pode ter no máximo 60 caracteres.")]
        public string Plataforma { get; set; }

        [Display(Name = "Fornecedor:")]
        [Required(ErrorMessage = "O Fornecedor do jogo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "A fornecedor do jogo pode ter no máximo 100 caracteres.")]
        public string Fornecedor { get; set; }

        [Display(Name = "Descrição:")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "A Descrição do jogo é obrigatório.")]
        [MaxLength(255, ErrorMessage = "A Descrição do jogo pode ter no máximo 255 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Link:")]
        public string Link { get; set; }
    }
}