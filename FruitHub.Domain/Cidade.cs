using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Domain
{
    public class Cidade : BaseEntity
    {
        public string Nome { get; set; }
        public string Abreviacao { get; set; }

        [ForeignKey("Estado")]
        public long EstadoId { get; set; }

        public virtual Estado estado { get; set; } 
    }
}
