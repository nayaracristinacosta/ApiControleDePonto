using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDePonto.Controllers
{
    [ApiController]
    public class EquipeController : ControllerBase
    {
        private readonly EquipeService _service;
        public EquipeController(EquipeService service)
        {
            _service = service;
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar uma equipe - 
        /// Campos obrigatórios: descricao
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "3")]
        [HttpGet("Equipe")]
        public IActionResult Listar([FromQuery] int descricao)
        {
            return StatusCode(200, _service.Listar(descricao));
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar uma equipe -
        /// Campos obrigatórios: equipeId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "3")]
        [HttpGet("EquipeId")]
        public IActionResult ObterPorId([FromQuery] int EquipeId)
        {
            return StatusCode(200, _service.Obter(EquipeId));
        }

        /// <summary>
        /// Através dessa rota você será capaz de cadastrar uma equipe - 
        /// Campos obrigatórios: liderancaId, funcionarioId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPost("Equipe")]
        public IActionResult Inserir([FromBody] Equipe model)
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
        /// Através dessa rota você será capaz de cadastrar uma equipe - 
        /// Campos obrigatórios: equipeId, liderancaId, funcionarioId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPost("Equipe/Funcionario")]
        public IActionResult InserirFuncionario([FromBody] Equipe model)
        {
            try
            {
                _service.InserirFuncionario(model);
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
        /// Através dessa rota você será capaz de deletar uma equipe - 
        /// Campos obrigatórios: equipeId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpDelete("Equipe/EquipeId")]
        public IActionResult Deletar([FromQuery] int EquipeId)
        {
            _service.Deletar(EquipeId);
            return StatusCode(200);
        }

        /// <summary>
        /// Através dessa rota você será capaz de atualizar uma equipe - 
        /// Campos obrigatórios: equipeId, liderancaId, funcionarioId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPut("Equipe")]
        public IActionResult Atualizar([FromBody] Equipe model)
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
