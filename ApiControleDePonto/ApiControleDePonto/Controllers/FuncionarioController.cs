using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDePonto.Controllers
{
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _service;
        public FuncionarioController(FuncionarioService service)
        {
            _service = service;
        }

        [HttpGet("Funcionario")]
        public IActionResult Listar([FromQuery] string? nomeDoFuncionário)
        {
            return StatusCode(200, _service.Listar(nomeDoFuncionário));
        }

        [HttpGet("FuncionarioId")]
        public IActionResult ObterPorId([FromQuery] int FuncionarioId)
        {
            return StatusCode(200, _service.Obter(FuncionarioId));
        }

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

        [HttpDelete("Funcionario/FuncionarioId")]
        public IActionResult Deletar([FromQuery] int funcionarioId)
        {
            _service.Deletar(funcionarioId);
            return StatusCode(200);
        }

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

