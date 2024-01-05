using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaAPI.Models.Entities
{
    public class Autor
    {
        [Key]
        public int idt_autor { get; set; }
        
        [Column(TypeName="varchar(45)")]
        public string nom_autor { get; set; }
    }
}