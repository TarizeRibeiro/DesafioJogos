using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Jogo : BaseEntity
    {
        public virtual string Nome { get; set; }

        public virtual int Plataforma { get; set; }

        public virtual bool InEmprestado { get; set; }

        //public byte Foto { get; set; }
    }
}
