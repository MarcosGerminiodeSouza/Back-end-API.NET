using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaAPI.Models.Entities
{
    public class LivroOld
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Imagem { get; set; }
    }
}