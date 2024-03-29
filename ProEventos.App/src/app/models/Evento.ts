export interface Evento {
  id_Evento: number;
  dt_Evento?: Date;
  ds_Tema: string;
  qtd_Pessoas: number;
  ds_Imagem: string;
  id_Palestrante: number;
  ds_Palestrante: string;
  id_RedeSocial: number;
  ds_RedeSocial: string;
  ds_UrlRedeSocial: string;
  ds_Logradouro: string;
  ds_Numero: string;
  ds_Complemento?: string;
  ds_Cep: string;
  ds_Bairro: string;
  id_Cidade: number;
  ds_Cidade: string;
  id_Estado: number;
  ds_Estado: string;
  cd_Estado: string;
  ds_Lote: string;
  vl_Valor: number;
  dt_Inicio?: Date;
  dt_Fim?: Date;
  qtd_Lote: number;
  ds_Telefone: string;
  ds_Celular: string;
  ds_Email: string;

}
