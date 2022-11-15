using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Domain.Models
{
    public class Pessoa
    {
        public int Id_Pessoa { get; set; }
        public int Id_TipoPessoa { get; set; }
        public string Ds_CpfCnpj { get; set; }
        public string Ds_InscRg { get; set; }
    }
}
