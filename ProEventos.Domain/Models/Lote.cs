namespace ProEventos.Domain.Models
{
    public class Lote
    {
        public int Id_Lote { get; set; }
        public int Ds_Lote { get; set; }
        public decimal Vl_Valor { get; set; }
        public DateTime? Dt_Inicio { get; set; }
        public DateTime? Dt_Fim { get; set; }
        public int Qtd_Lote { get; set; }
        public int Id_EventoLote { get; set; }
    }
}
