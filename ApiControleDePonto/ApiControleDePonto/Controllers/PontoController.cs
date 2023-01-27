using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDePonto.Controllers
{
    [ApiController]
    public class PontoController : ControllerBase
    {
        private readonly PontoService _service;
        public PontoController()
        {
            _service = new PontoService();
        }

        [HttpGet("Ponto")]
        public IActionResult Listar([FromQuery] int funcionarioId)
        {
            return StatusCode(200, _service.Listar(funcionarioId));
        }

        [HttpGet("PontoId")]
        public IActionResult ObterPorId([FromQuery] int PontoId)
        {
            return StatusCode(200, _service.Obter(PontoId));
        }

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


        [HttpDelete("Ponto/PontoId")]
        public IActionResult Deletar([FromQuery] int PontoId)
        {
            _service.Deletar(PontoId);
            return StatusCode(200);
        }

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
