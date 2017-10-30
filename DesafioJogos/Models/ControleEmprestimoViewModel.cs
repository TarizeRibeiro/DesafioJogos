using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioJogos.Models
{
    [Serializable]
    public class ControleEmprestimoViewModel
    {
        public int Id { get; set; }

        [DisplayName("Data de Atualização")]
        public virtual string DataAtualizacao { get; set; }

        [DisplayName("Amigo")]
        public virtual AmigoViewModel Amigo { get; set; }

        [DisplayName("Jogo")]
        public virtual JogoViewModel Jogo { get; set; }
        
        public virtual bool InEmprestado { get; set; }
    }
}
