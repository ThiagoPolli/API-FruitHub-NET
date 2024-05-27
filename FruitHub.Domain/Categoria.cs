using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitHub.Domain
{
    public class Categoria : BaseEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
