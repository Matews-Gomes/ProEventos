using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProEventos.Domain.Interface;
using ProEventos.Domain.Models;

namespace ProEventos.Data.Repository
{
    public class EventoRepository : IEventoRepository
    {
        public string Connection { get; set; }
        public IConfiguration _configuration;

        public EventoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            Connection = _configuration.GetConnectionString("DefaultConnection");
        }   

        public async Task<IEnumerable<Evento>> GetAllAsync()
        {
            List<Evento> events = new();

            using SqlConnection conn = new(Connection);
            conn.Open();

            try
            {
                SqlCommand cmd = new("ESP_EVENTO_SEL", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    events.Add(new Evento()
                    {
                        Id_Evento = Convert.ToInt32(reader["Id_Evento"]),
                        Ds_Tema = reader["Ds_Tema"].ToString().ToUpper(),
                        Ds_Lote = reader["Ds_Lote"].ToString().ToUpper(),
                        Ds_Imagem = reader["Ds_ImagemUrl"].ToString(),                        
                        Dt_Evento = Convert.ToDateTime(reader["Dt_Evento"]),
                        Qtd_Pessoas = Convert.ToInt32(reader["Qtd_Pessoas"]),
                        Ds_RedeSocial = reader["Ds_RedeSocial"].ToString().ToUpper(),
                        Ds_UrlRedeSocial = reader["Ds_UrlRedeSocial"].ToString().ToUpper(),
                        Ds_Palestrante = reader["Ds_Palestrante"].ToString().ToUpper(),
                        Ds_Cidade = reader["Ds_Cidade"].ToString().ToUpper(),
                        Cd_Estado = reader["Cd_Estado"].ToString().ToUpper(),
                        Ds_Telefone = reader["Ds_telefone"].ToString().ToUpper(),
                        Ds_Celular = reader["Ds_Celular"].ToString().ToUpper(),
                        Vl_Valor = Convert.ToDecimal(reader["Vl_Valor"]),
                        Ds_Email = reader["Ds_Email"].ToString().ToUpper()
                    });
                }

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<Evento> GetByIdAsync(int id)
        {
            Evento eventoById = new();

            using SqlConnection conn = new(Connection);
            conn.Open();

            try
            {
                SqlCommand cmd = new("ESP_EVENTO_SEL_BY_ID", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id_Evento", id);
                var reader = await cmd.ExecuteReaderAsync();
                while (reader.Read())
                {
                    Evento evento = new()
                    {
                        Id_Evento = id,
                        Ds_Tema = reader["Ds_Tema"].ToString().ToUpper(),
                        Ds_Lote = reader["Ds_Lote"].ToString().ToUpper(),
                        Ds_Imagem = reader["Ds_ImagemUrl"].ToString(),
                        Dt_Evento = Convert.ToDateTime(reader["Dt_Evento"]),
                        Qtd_Pessoas = Convert.ToInt32(reader["Qtd_Pessoas"]),
                        Id_RedeSocial = Convert.ToInt32(reader["Id_RedeSocial"]),
                        Ds_RedeSocial = reader["Ds_RedeSocial"].ToString().ToUpper(),
                        Ds_UrlRedeSocial = reader["Ds_UrlRedeSocial"].ToString().ToUpper(),
                        Id_Palestrante = Convert.ToInt32(reader["Id_Palestrante"]),
                        Ds_Palestrante = reader["Ds_Palestrante"].ToString().ToUpper(),
                        Ds_Logradouro = reader["Ds_Logradouro"].ToString().ToUpper(),
                        Ds_Numero = reader["Ds_Numero"].ToString().ToUpper(),
                        Ds_Cep = reader["Ds_Cep"].ToString().ToUpper(),
                        Ds_Complemento = reader["Ds_complemento"].ToString().ToUpper(),
                        Ds_Bairro = reader["Ds_Bairro"].ToString().ToUpper(),
                        Ds_Cidade = reader["Ds_Cidade"].ToString().ToUpper(),
                        Cd_Estado = reader["Cd_Estado"].ToString().ToUpper(),
                        Ds_Telefone = reader["Ds_telefone"].ToString().ToUpper(),
                        Ds_Celular = reader["Ds_Celular"].ToString().ToUpper(),
                        Ds_Email = reader["Ds_Email"].ToString().ToUpper(),
                        Dt_Inicio = Convert.ToDateTime(reader["Dt_Inicio"]),
                        Dt_Fim = Convert.ToDateTime(reader["Dt_Fim"]),
                        Qtd_Lote = Convert.ToInt32(reader["Qtd_Lote"]),
                        Vl_Valor = Convert.ToDecimal(reader["Vl_Valor"])
                    };

                    eventoById = evento;
                }

                return eventoById;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task AddAsync(Evento entity)
        {
            using SqlConnection conn = new(Connection);

            conn.Open();

            try
            {
                SqlCommand cmd = new("ESP_EVENTO_INS", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id_RedeSocial", entity.Id_RedeSocial);
                cmd.Parameters.AddWithValue("@Id_Palestrante", entity.Id_Palestrante);
                cmd.Parameters.AddWithValue("@Ds_UrlRedeSocial", entity.Ds_UrlRedeSocial);
                cmd.Parameters.AddWithValue("@Dt_Evento", entity.Dt_Evento);
                cmd.Parameters.AddWithValue("@Ds_Tema", entity.Ds_Tema);
                cmd.Parameters.AddWithValue("@Qtd_Pessoas", entity.Qtd_Pessoas);
                cmd.Parameters.AddWithValue("@Ds_imagem", entity.Ds_Imagem);
                cmd.Parameters.AddWithValue("@Ds_Lote", entity.Ds_Lote);
                cmd.Parameters.AddWithValue("@Vl_Valor", entity.Vl_Valor);
                cmd.Parameters.AddWithValue("@Dt_Inicio", entity.Dt_Inicio);
                cmd.Parameters.AddWithValue("@Dt_Fim", entity.Dt_Fim);
                cmd.Parameters.AddWithValue("@Qtd_Lote", entity.Qtd_Lote);
                cmd.Parameters.AddWithValue("@Ds_Telefone", entity.Ds_Telefone);
                cmd.Parameters.AddWithValue("@Ds_Celular", entity.Ds_Celular);
                cmd.Parameters.AddWithValue("@Ds_Email", entity.Ds_Email);
                cmd.Parameters.AddWithValue("@Ds_Logradouro", entity.Ds_Logradouro);
                cmd.Parameters.AddWithValue("@Ds_Numero", entity.Ds_Numero);
                cmd.Parameters.AddWithValue("@Ds_Complemento", entity.Ds_Complemento);
                cmd.Parameters.AddWithValue("@Ds_Cep", entity.Ds_Cep);
                cmd.Parameters.AddWithValue("@Ds_Bairro", entity.Ds_Bairro);
                cmd.Parameters.AddWithValue("@Id_Cidade", entity.Id_Cidade);
                cmd.Parameters.AddWithValue("@Id_Estado", entity.Id_Estado);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task UpdateAsync(Evento entity)
        {
            using SqlConnection conn = new(Connection);
            conn.Open();

            try
            {
                SqlCommand cmd = new("ESP_EVENTO_UPD", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id_RedeSocial", entity.Id_RedeSocial);
                cmd.Parameters.AddWithValue("@Id_Palestrante", entity.Id_Palestrante);
                cmd.Parameters.AddWithValue("@Ds_UrlRedeSocial", entity.Ds_UrlRedeSocial);
                cmd.Parameters.AddWithValue("@Dt_Evento", entity.Dt_Evento);
                cmd.Parameters.AddWithValue("@Ds_Tema", entity.Ds_Tema);
                cmd.Parameters.AddWithValue("@Qtd_Pessoas", entity.Qtd_Pessoas);
                cmd.Parameters.AddWithValue("@Ds_imagem", entity.Ds_Imagem);
                cmd.Parameters.AddWithValue("@Ds_Lote", entity.Ds_Lote);
                cmd.Parameters.AddWithValue("@Vl_Valor", entity.Vl_Valor);
                cmd.Parameters.AddWithValue("@Dt_Inicio", entity.Dt_Inicio);
                cmd.Parameters.AddWithValue("@Dt_Fim", entity.Dt_Fim);
                cmd.Parameters.AddWithValue("@Qtd_Lote", entity.Qtd_Lote);
                cmd.Parameters.AddWithValue("@Ds_Telefone", entity.Ds_Telefone);
                cmd.Parameters.AddWithValue("@Ds_Celular", entity.Ds_Celular);
                cmd.Parameters.AddWithValue("@Ds_Email", entity.Ds_Email);
                cmd.Parameters.AddWithValue("@Ds_Logradouro", entity.Ds_Logradouro);
                cmd.Parameters.AddWithValue("@Ds_Numero", entity.Ds_Numero);
                cmd.Parameters.AddWithValue("@Ds_Complemento", entity.Ds_Complemento);
                cmd.Parameters.AddWithValue("@Ds_Cep", entity.Ds_Cep);
                cmd.Parameters.AddWithValue("@Ds_Bairro", entity.Ds_Bairro);
                cmd.Parameters.AddWithValue("@Id_Cidade", entity.Id_Cidade);
                cmd.Parameters.AddWithValue("@Id_Estado", entity.Id_Estado);

                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using SqlConnection conn = new(Connection);
            conn.Open();

            try
            {
                SqlCommand cmd = new("ESP_EVENTO_DEL", conn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Id_Evento", id);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
