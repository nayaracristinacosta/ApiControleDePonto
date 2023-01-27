using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiControleDePonto.Controllers
{
    [ApiController]
    public class liderancaController : ControllerBase
    {
        private readonly LiderancaService _service;
        public liderancaController()
        {
            _service = new LiderancaService();
        }

        [HttpGet("lideranca")]
        public IActionResult Listar([FromQuery] string? descricaoEquipe)
        {
            return StatusCode(200, _service.Listar(descricaoEquipe));
        }

        [HttpGet("liderancaId")]
        public IActionResult ObterPorId([FromQuery] int liderancaId)
        {
            return StatusCode(200, _service.Obter(liderancaId));
        }

        [HttpPost("lideranca")]
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


        [HttpDelete("lideranca/liderancaId")]
        public IActionResult Deletar([FromQuery] int liderancaId)
        {
            _service.Deletar(liderancaId);
            return StatusCode(200);
        }

        [HttpPut("lideranca")]
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
