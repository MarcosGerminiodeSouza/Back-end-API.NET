using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace livrariaAPI.Models.Entities
{
    public class Editora
    {
        [Key]
        public int idt_editora { get; set; }

        [Column(TypeName="varchar(45)")]
        public string nom_editora { get; set; }
    }
}