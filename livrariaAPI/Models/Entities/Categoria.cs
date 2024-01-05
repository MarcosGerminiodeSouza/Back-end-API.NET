using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaAPI.Models.Entities
{
    public class Categoria
    {
        [Key]
        public int idt_categoria { get; set; }
        
        [Column(TypeName="varchar(45)")]
        public string des_categoria { get; set; }
    }
}