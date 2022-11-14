using Microsoft.AspNetCore.Mvc;
using NET6_Calculator_API.Data.Interfaces;

namespace NET6_Calculator_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggerController : Controller
    {
        private readonly ILoggerRepository _loggerRepository;

        public LoggerController(ILoggerRepository loggerRepository)
        {
            _loggerRepository = loggerRepository;
        }

        // GET: api/Get
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _loggerRepository.GetLogs();

                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE: api/Delete
        [HttpDelete]
        [Produces("application/json")]
        public async Task<ActionResult> Clear()
        {
            try
            {
                await _loggerRepository.ClearLogs();

                return Ok("All logs cleared");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
