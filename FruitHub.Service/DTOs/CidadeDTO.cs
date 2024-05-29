using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Service.DTOs
{
    public class CidadeDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Abreviacao { get; set; }
        public long EstadoId { get; set; }
    }
}
