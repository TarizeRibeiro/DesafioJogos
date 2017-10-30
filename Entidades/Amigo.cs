using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Amigo : BaseEntity
    {
        public virtual string Nome { get; set; }

        public virtual string Email { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string Celular { get; set; }
    }
}
