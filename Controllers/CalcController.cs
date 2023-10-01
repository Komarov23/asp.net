using lab1.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CalcController : Controller
    {
        private readonly CalcService _calcService;

        public CalcController(CalcService calcService)
        {
            _calcService = calcService;
        }

        [HttpGet("add")]
        public IActionResult Add(int a, int b)
        {
            return Ok(_calcService.Add(a, b));
        }

        [HttpGet("subtract")]
        public IActionResult Subtract(int a, int b)
        {
            int result = _calcService.Subtract(a, b);
            return Ok(result);
        }

        [HttpGet("multiply")]
        public IActionResult Multiply(int a, int b)
        {
            int result = _calcService.Multiply(a, b);
            return Ok(result);
        }

        [HttpGet("divide")]
        public IActionResult Divide(int a, int b)
        {
            int result = _calcService.Divide(a, b);
            return Ok(result);
        }

    }
}
