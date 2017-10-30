using System;
using System.ComponentModel;

namespace DesafioJogos.Models
{
    [Serializable]
    public class JogoViewModel
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Nome { get; set; }

        [DisplayName("Plataforma")]
        public int? Plataforma { get; set; }

        public bool InEmprestado { get; set; }

        public string PlataformaDescricao { get; set; }
        public string EmprestadoFormatado { get; set; }
    }
}
