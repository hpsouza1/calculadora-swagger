using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace calculador_swagger.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        private bool ValidarNumero(string valor)
        {
            return double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out _);
        }

        [HttpGet("somar")]
        public IActionResult Somar([FromQuery] string numero1, [FromQuery] string numero2)
        {
            if (!ValidarNumero(numero1) || !ValidarNumero(numero2))
            {
                return BadRequest("Os parâmetros devem ser números válidos.");
            }

            double num1 = double.Parse(numero1, CultureInfo.InvariantCulture);
            double num2 = double.Parse(numero2, CultureInfo.InvariantCulture);
            double resultado = num1 + num2;

            return Ok(new { resultado });
        }

        [HttpGet("subtrair")]
        public IActionResult Subtrair([FromQuery] string numero1, [FromQuery] string numero2)
        {
            if (!ValidarNumero(numero1) || !ValidarNumero(numero2))
            {
                return BadRequest("Os parâmetros devem ser números válidos.");
            }

            double num1 = double.Parse(numero1, CultureInfo.InvariantCulture);
            double num2 = double.Parse(numero2, CultureInfo.InvariantCulture);
            double resultado = num1 - num2;

            return Ok(new { resultado });
        }

        [HttpGet("dividir")]
        public IActionResult Dividir([FromQuery] string numero1, [FromQuery] string numero2)
        {
            if (!ValidarNumero(numero1) || !ValidarNumero(numero2))
            {
                return BadRequest("Os parâmetros devem ser números válidos.");
            }

            double num1 = double.Parse(numero1, CultureInfo.InvariantCulture);
            double num2 = double.Parse(numero2, CultureInfo.InvariantCulture);

            if (num2 == 0)
            {
                return BadRequest("Divisão por zero não é permitida.");
            }

            double resultado = num1 / num2;
            return Ok(new { resultado });
        }
    }
}
