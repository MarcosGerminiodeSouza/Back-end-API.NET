using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaAPI.Models.Entities
{
    public class LivroVenda
    {
        [Key]
        public int idt_livro_venda { get; set; }

        [ForeignKey("Livro")]
        public int idt_livro { get; set; }
        public virtual Livro Livro { get; set; }

        [ForeignKey("Venda")]
        public int idt_venda { get; set; }
        public virtual Venda Venda { get; set; }

        [Column(TypeName ="int")]
        public int qtd_livro { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        public decimal val_livro { get; set; }
    }
}