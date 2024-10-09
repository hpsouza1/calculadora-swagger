using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace calculador_swagger.Controllers
{
    public class OperacaoRequest
    {
        [Required(ErrorMessage = "O campo numero1 é obrigatório.")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "O campo numero1 deve ser um número válido.")]
        public double Numero1 { get; set; }

        [Required(ErrorMessage = "O campo numero2 é obrigatório.")]
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "O campo numero2 deve ser um número válido.")]
        public double Numero2 { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("somar")]
        public IActionResult Somar([FromQuery] OperacaoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            double resultado = request.Numero1 + request.Numero2;
            return Ok(new { resultado });
        }

        [HttpGet("subtrair")]
        public IActionResult Subtrair([FromQuery] OperacaoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            double resultado = request.Numero1 - request.Numero2;
            return Ok(new { resultado });
        }

        [HttpGet("dividir")]
        public IActionResult Dividir([FromQuery] OperacaoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (request.Numero2 == 0)
            {
                return BadRequest("Divisão por zero não é permitida.");
            }

            double resultado = request.Numero1 / request.Numero2;
            return Ok(new { resultado });
        }

        [HttpGet("multiplicar")]
        public IActionResult Multiplicar([FromQuery] OperacaoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            double resultado = request.Numero1 * request.Numero2;
            return Ok(new { resultado });
        }
    }
}
    