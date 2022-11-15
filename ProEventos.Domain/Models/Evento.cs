namespace ProEventos.Domain.Models
{
    public class Evento
    {
        public int Id_Evento { get; set; }
        public DateTime? Dt_Evento { get; set; }
        public string Ds_Tema { get; set; }
        public int Qtd_Pessoas { get; set; }               
        public string Ds_Imagem { get; set; }
        public int Id_Palestrante { get; set; }
        public string Ds_Palestrante { get; set; }
        public int Id_RedeSocial { get; set; }
        public string Ds_RedeSocial { get; set; }
        public string Ds_UrlRedeSocial { get; set; }
        public string Ds_Logradouro { get; set; }
        public string Ds_Numero { get; set; }
        public string Ds_Complemento { get; set; }
        public string Ds_Cep { get; set; }
        public string Ds_Bairro { get; set; }
        public int Id_Cidade { get; set; }
        public string Ds_Cidade { get; set; }
        public int Id_Estado { get; set; }
        public string Ds_Estado { get; set; }
        public string Cd_Estado { get; set; }
        public string Ds_Lote { get; set; }
        public decimal Vl_Valor { get; set; }
        public DateTime? Dt_Inicio { get; set; }
        public DateTime? Dt_Fim { get; set; }
        public int Qtd_Lote { get; set; }        
        public string Ds_Telefone { get; set; }
        public string Ds_Celular { get; set; }
        public string Ds_Email { get; set; }
        
    }
}
