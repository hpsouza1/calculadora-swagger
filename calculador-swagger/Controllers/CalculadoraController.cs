using Microsoft.AspNetCore.Mvc;

namespace calculador_swagger.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("somar")]
        public IActionResult Somar([FromQuery] double numero1, [FromQuery] double numero2)
        {
            double resultado = numero1 + numero2;
            return Ok(new { resultado });
        }

        [HttpGet("subtrair")]
        public IActionResult Subtrair([FromQuery] double numero1, [FromQuery] double numero2)
        {
            double resultado = numero1 - numero2;
            return Ok(new { resultado });
        }

        [HttpGet("dividir")]
        public IActionResult Dividir([FromQuery] double numero1, [FromQuery] double numero2)
        {
            if (numero2 == 0)
            {
                return BadRequest("Divisão por zero não é permitida.");
            }

            double resultado = numero1 / numero2;
            return Ok(new { resultado });
        }
    }
}
