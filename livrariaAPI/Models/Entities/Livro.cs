using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaAPI.Models.Entities
{
    public class Livro
    {
        [Key()]
        public int LivroId { get; set; }
        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        // lazy load
        public virtual Autor Autor { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public Editora Editora { get; set; }
        public int EditoraId { get; set; }
        public string Titulo { get; set; }
        public string Temporada { get; set; }
        public int NumeroDoAno { get; set; }
        public decimal ValorLivro { get; set; }
        public string Img { get; set; }
        public string Lancamento { get; set; }
        public int QuantidadeLivroEstoque { get; set; }
    }
}