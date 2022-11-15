using Microsoft.AspNetCore.Mvc;
using ProEventos.Domain.Interface;
using ProEventos.Domain.Models;

namespace ProEventos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {

        private readonly IEventoRepository _eventoRepository;

        public EventosController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        [HttpGet]
        public  async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _eventoRepository.GetAllAsync();
                if (eventos == null) return NotFound("Nenhum registro encontrado!");

                return Ok(eventos);
            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar registros. error: {ex.Message}");
            }           
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var evento = await _eventoRepository.GetByIdAsync(id);
                if (evento == null) return NotFound("Nenhum registro encontrado!");

                return Ok(evento);

            }
            catch (Exception ex)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar recuperar registros. error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento entity)
        {

            try
            {
                if (entity == null) return BadRequest("Erro ao tentar salvar o registro");

                await _eventoRepository.AddAsync(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar salvar registro. error: {ex.Message}");
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Evento entity)
        {            

            try
            {
                if (id != entity.Id_Evento) return this.StatusCode(StatusCodes.Status400BadRequest,
                                                        $"Error impossivel atualizar registro.");

                await _eventoRepository.UpdateAsync(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                        $"Erro ao tentar atualizar registro. error: {ex.Message}");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    await _eventoRepository.DeleteAsync(id);
                    return Ok("Deletado com sucesso");                   
                }
                else
                {
                    return BadRequest("Impossivel deletar o registro.");
                }
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                            $"Erro ao tentar deletar registro. error: {ex.Message}");
            }
        }
    }
}