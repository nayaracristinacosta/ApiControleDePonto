using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDePonto.Controllers
{
    [ApiController]
    public class LiderancaController : ControllerBase
    {
        private readonly LiderancaService _service;
        public LiderancaController(LiderancaService service)
        {
            _service = service;
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar uma liderança - 
        /// Campos obrigatórios: descricaoEquipe
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "3")]
        [HttpGet("Lideranca")]
        public IActionResult Listar([FromQuery] string? descricaoEquipe)
        {
            return StatusCode(200, _service.Listar(descricaoEquipe));
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar uma liderança - 
        /// Campos obrigatórios: liderancaId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "3")]
        [HttpGet("LiderancaId")]
        public IActionResult ObterPorId([FromQuery] int liderancaId)
        {
            return StatusCode(200, _service.Obter(liderancaId));
        }

        /// <summary>
        /// Através dessa rota você será capaz de cadastrar uma liderança - 
        /// Campos obrigatórios: funcionarioId, descricaoEquipe
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPost("Lideranca")]
        public IActionResult Inserir([FromBody] Lideranca model)
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
        /// Através dessa rota você será capaz de deletar uma liderança - 
        /// Campos obrigatórios: liderancaId 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpDelete("Lideranca/LiderancaId")]
        public IActionResult Deletar([FromQuery] int liderancaId)
        {
            _service.Deletar(liderancaId);
            return StatusCode(200);
        }


        /// <summary>
        /// Através dessa rota você será capaz de atualizar uma liderança - 
        /// Campos obrigatórios: liderancaId, funcionarioId, descricaoEquipe
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPut("Lideranca")]
        public IActionResult Atualizar([FromBody] Lideranca model)
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
