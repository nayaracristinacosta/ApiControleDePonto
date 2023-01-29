using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ApiControleDePonto.Controllers
{
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly CargoService _service;
        public CargoController(CargoService service)
        {
            _service = service;
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar um cargo - 
        /// Campos obrigatórios: descricao
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "3")]
        [HttpGet("Cargo")]
        public IActionResult Listar([FromQuery] string? descricao)
        {
            return StatusCode(200, _service.Listar(descricao));
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar um cargo -
        /// Campos obrigatórios: cargoId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "3")]
        [HttpGet("CargoId")]
        public IActionResult ObterPorId([FromQuery] int cargoId)
        {
            return StatusCode(200, _service.Obter(cargoId));
        }

        /// <summary>
        /// Através dessa rota você será capaz de cadastrar um cargo - 
        /// Campos obrigatórios: descricao
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPost("Cargo")]
        public IActionResult Inserir([FromBody] Cargo model)
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
        /// Através dessa rota você será capaz de deletar um cargo - 
        /// Campos obrigatórios: cargoId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpDelete("Cargo/CargoId")]
        public IActionResult Deletar([FromQuery] int cargoId)
        {
            _service.Deletar(cargoId);
            return StatusCode(200);
        }

        /// <summary>
        /// Através dessa rota você será capaz de atualizar um cargo - 
        /// Campos obrigatórios: cargoId, descricao
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPut("Cargo")]
        public IActionResult Atualizar([FromBody] Cargo model)
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
