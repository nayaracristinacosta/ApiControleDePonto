using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDePonto.Controllers
{
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly PontoService _service;
        public PontoController(PontoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar um ponto - 
        /// Campos obrigatórios: funcionarioId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>        
        [AllowAnonymous]
        [HttpGet("Ponto")]
        public IActionResult Listar([FromQuery] int funcionarioId)
        {
            return StatusCode(200, _service.Listar(funcionarioId));
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar  um ponto - 
        /// Campos obrigatórios: pontoId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpGet("PontoId")]
        public IActionResult ObterPorId([FromQuery] int pontoId)
        {
            return StatusCode(200, _service.Obter(pontoId));
        }

        /// <summary>
        /// Através dessa rota você será capaz de cadastrar  um ponto - 
        /// Campos obrigatórios: dataHorarioPonto, funcionarioId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "4")]
        [HttpPost("Ponto")]
        public IActionResult Inserir([FromBody] Ponto model)
        {
            try
            {
                _service.Inserir(model);
                return StatusCode(201);
            }
            catch (ValidacaoException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }

        /// <summary>
        /// Através dessa rota você será capaz de deletar  um ponto - 
        /// Campos obrigatórios: pontoId 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpDelete("Ponto/PontoId")]
        public IActionResult Deletar([FromQuery] int pontoId)
        {
            _service.Deletar(pontoId);
            return StatusCode(200);
        }

        /// <summary>
        /// Através dessa rota você será capaz de atualizar um ponto - 
        /// Campos obrigatórios: pontoId, dataHorarioPonto, justificativa, funcionarioId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPut("Ponto")]
        public IActionResult Atualizar([FromBody] Ponto model)
        {
            try
            {
                _service.Atualizar(model);
                return StatusCode(201);
            }
            catch (ValidacaoException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.ToString());
            }
        }
    }
}
