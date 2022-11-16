export interface Lote {
  id_lote: number;
  ds_lote: number;
  vl_valor: number;
  dt_inicio?: Date;
  dt_fim?: Date;
  qtd_lote: number;
  id_eventolote: number;
}
