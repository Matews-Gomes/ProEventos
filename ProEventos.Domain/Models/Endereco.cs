using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Models
{
    public class Endereco
    {
        public int Id_Endereco { get; set; }
        public string Ds_Logradouro { get; set; }
        public string Ds_Numero { get; set; }
        public string Ds_Complemento { get; set; }
        public string Ds_Cep { get; set; }
        public string Ds_Bairro { get; set; }
        public int Id_Cidade { get; set; }
        public int Id_Estado { get; set; }
        public int Id_PessoaEndereco { get; set; }
        public int Id_EventoEndereco { get; set; }
    }
}
