using Microsoft.AspNetCore.Mvc;
using NET6_Calculator_API.Data.Interfaces;

namespace NET6_Calculator_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultiplyController : Controller
    {
        private readonly ILoggerRepository _loggerRepository;

        public MultiplyController(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        // GET: api/Multiply
        [HttpGet(Name = "Multiply")]
        [Produces("application/json")]
        public async Task<ActionResult> Multiply(float a, float b)
        {
            float? result = null;
            var success = false;

            try
            {
                result = a * b;
                success = true;

                return Ok(result);
            }
            catch (Exception error)
            {
                return BadRequest(error);
            }
            finally
            {
                // Log Error
                await _loggerRepository.Post(a, "+", b, result, success);
            }
        }
    }
}
