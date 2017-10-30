using System;
using System.ComponentModel;

namespace DesafioJogos.Models
{
    [Serializable]
    public class AmigoViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }

        [DisplayName("Celular")]
        public string Celular { get; set; }
    }
}
