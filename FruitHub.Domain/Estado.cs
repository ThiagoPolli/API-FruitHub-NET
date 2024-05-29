using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Domain
{
    public class Estado : BaseEntity
    {
        public string Nome { get; set; }
        public string Sigla { get; set; }
    }
}
