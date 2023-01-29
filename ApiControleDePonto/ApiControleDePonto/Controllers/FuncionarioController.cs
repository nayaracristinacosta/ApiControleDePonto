using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using ApiSupermecado.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDePonto.Controllers
{
    [AllowAnonymous]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;
        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar um funcionário - 
        /// Campos obrigatórios: nomeDoFuncionario
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "1")]
        [Authorize(Roles = "2")]
        [Authorize(Roles = "3")]
        [HttpGet("Funcionario")]
        [ProducesResponseType(typeof(Funcionario), 200)]
        [ProducesResponseType(401)]
        public IActionResult Listar([FromQuery] string? nomeDoFuncionário)
        {
            return StatusCode(200, _service.Listar(nomeDoFuncionário));
        }

        /// <summary>
        /// Através dessa rota você será capaz de listar um funcionário -
        /// Campos obrigatórios: funcionarioId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [AllowAnonymous]
        [HttpGet("FuncionarioId")]
        public IActionResult ObterPorId([FromQuery] int funcionarioId)
        {
            return StatusCode(200, _service.Obter(funcionarioId));
        }

        /// <summary>
        /// Através dessa rota você será capaz de cadastrar um funcionário - 
        /// Campos obrigatórios: nomeDoFuncionario, cpf, nascimentoFuncionario, dataDeAdmissao, celularFuncionario, emailFuncionario, senhaFuncionario, cargoId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPost("Funcionario")]
        public IActionResult Inserir([FromBody] Funcionario model)
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
        /// Através dessa rota você será capaz de deletar um funcionário - 
        /// Campos obrigatórios: funcionarioId 
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpDelete("Funcionario/FuncionarioId")]
        public IActionResult Deletar([FromQuery] int funcionarioId)
        {
            _service.Deletar(funcionarioId);
            return StatusCode(200);
        }

        /// <summary>
        /// Através dessa rota você será capaz de atualizar um funcionário - 
        /// Campos obrigatórios: funcionarioId, nomeDoFuncionario, cpf, nascimentoFuncionario, dataDeAdmissao, celularFuncionario, emailFuncionario, senhaFuncionario, cargoId
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Sucesso, e retorna o elemento encontrado via ID</response>
        [Authorize(Roles = "2")]
        [HttpPut("Funcionario")]
        public IActionResult Atualizar([FromBody] Funcionario model)
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

