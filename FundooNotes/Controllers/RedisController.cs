using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        private readonly IDatabase _db;

        public RedisController(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        [HttpPost("set")]
        public async Task<IActionResult> Set(string key, string value)
        {
            await _db.StringSetAsync(key, value);

            return Ok("Data stored in Redis");
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get(string key)
        {
            var value = await _db.StringGetAsync(key);

            return Ok(value.ToString());
        }
    }
}