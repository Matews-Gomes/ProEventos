using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Models
{
    public class Contato
    {
        public int Id_Contato { get; set; }
        public string Ds_Telefone { get; set; }
        public string Ds_Celular { get; set; }
        public string Ds_Email { get; set; }
        public int Id_PessoaContato { get; set; }
        public int Id_EventoContato { get; set; }
    }
}
