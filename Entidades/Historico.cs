using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Historico : BaseEntity
    {
        public virtual DateTime DataAtualizacao { get; set; }

        public virtual Jogo Jogo { get; set; }

        public virtual Amigo Amigo { get; set; }
    }
}
