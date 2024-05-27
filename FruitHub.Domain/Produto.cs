using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Domain
{
    public class Produto : BaseEntity
    {
        [Required]
        public string Nome { get; set; } 
        public string Descricao { get; set; }
        public decimal Preco { get; set; }

        [ForeignKey("Categoria")]
        public long CategoriaId { get; set; }

        public virtual Categoria categoria {  get; set; }

      
    }
}
