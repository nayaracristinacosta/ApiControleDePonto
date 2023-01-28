using ApiControleDePonto.Domain.Exceptions;
using ApiControleDePonto.Domain.Models;
using ApiControleDePonto.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("Cargo")]
        public IActionResult Listar([FromQuery] string? descricao)
        {
            return StatusCode(200, _service.Listar(descricao));
        }

        [HttpGet("CargoId")]
        public IActionResult ObterPorId([FromQuery] int cargoId)
        {
            return StatusCode(200, _service.Obter(cargoId));
        }

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


        [HttpDelete("Cargo/CargoId")]
        public IActionResult Deletar([FromQuery] int cargoId)
        {
            _service.Deletar(cargoId);
            return StatusCode(200);
        }

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
