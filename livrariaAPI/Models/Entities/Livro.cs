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
        [Key]
        public int idt_livro { get; set; }

        [ForeignKey("Autor")]
        public int idt_autor { get; set; }
        public virtual Autor Autor { get; set; } //Lazy Load

        [ForeignKey("Categoria")]
        public int idt_categoria { get; set; }
        public virtual Categoria Categoria { get; set; } //Lazy Load

        [ForeignKey("Editora")]
        public int idt_editora { get; set; }
        public virtual Editora Editora { get; set; } //Lazy Load

        [Column(TypeName="varchar(45)")]
        public string des_titulo { get; set; }

        [Column(TypeName="varchar(25)")]
        public string des_temporada { get; set; }

        [Column(TypeName="int")]
        public int num_ano { get; set; }

        [Column(TypeName = "decimal(6, 2)")]
        public decimal val_livro { get; set; }

        [Column(TypeName="varchar(45)")]
        public string des_imagem { get; set; }

        [Column(TypeName="char(1)")]
        public string ind_lancamento { get; set; }

        [Column(TypeName="int")]
        public int qtd_livro_estoque { get; set; }
    }
}