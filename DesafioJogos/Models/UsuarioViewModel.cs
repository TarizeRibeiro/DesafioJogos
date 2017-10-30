using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioJogos.Models
{
    [Serializable]
    public class UsuarioViewModel
    {
        [DisplayName("ID")]
        public int ID { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Senha")]
        public string Senha { get; set; }
    }
}
