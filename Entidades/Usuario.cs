using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Usuario : BaseEntity
    {
        public virtual string Nome { get; set; }
        public virtual string Senha { get; set; }
    }
}
