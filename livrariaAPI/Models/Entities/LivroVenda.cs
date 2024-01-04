using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LivrariaAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace livrariaAPI.Models.Entities
{
    public class LivroVenda
    {
        public int LivroVendaId { get; set; }
        public Livro Livro { get; set; }
        public int LivroId { get; set; }
        public Venda Venda { get; set; }
        public int VendaId { get; set; }
        public int QuantidadeLivro { get; set; }
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ValorLivro { get; set; }
    }
}