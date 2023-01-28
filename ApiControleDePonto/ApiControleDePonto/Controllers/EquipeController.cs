using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
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

        [HttpGet("Equipe")]
        public IActionResult Listar([FromQuery] int descricao)
        {
            return StatusCode(200, _service.Listar(descricao));
        }

        [HttpGet("EquipeId")]
        public IActionResult ObterPorId([FromQuery] int EquipeId)
        {
            return StatusCode(200, _service.Obter(EquipeId));
        }

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

        [HttpDelete("Equipe/EquipeId")]
        public IActionResult Deletar([FromQuery] int EquipeId)
        {
            _service.Deletar(EquipeId);
            return StatusCode(200);
        }

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
