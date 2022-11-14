using Microsoft.AspNetCore.Mvc;
using NET6_Calculator_API.Data.Interfaces;

namespace NET6_Calculator_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivideController : Controller
    {
        private readonly ILoggerRepository _loggerRepository;

        public DivideController(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        // GET: api/Divide
        [HttpGet(Name = "Divide")]
        [Produces("application/json")]
        public async Task<IActionResult> Divide(float a, float b)
        {
            try
            {
                if (a == 0 || b == 0)
                    throw new Exception("Cannot divide by 0");

                var result = a / b;

                // Log Result
                await _loggerRepository.Post(a, "/", b, result, true);

                return Ok(result);
            }
            catch (Exception error)
            {
                // Log Error
                await _loggerRepository.Post(a, "/", b, null, false);

                return BadRequest(error.Message);
            }
        }
    }
}
