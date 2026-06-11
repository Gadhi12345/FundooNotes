<<<<<<< HEAD
﻿namespace FundooNotes.Controllers
=======
﻿using BussinessLogicLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace FundooNotes.Controllers
>>>>>>> feature/Redis
{
    public class RedisController
    {
<<<<<<< HEAD
=======
        private readonly IRedisBLL _redisBLL;

        public RedisController(IRedisBLL redisBLL)
        {
            _redisBLL = redisBLL;
        }

        [HttpPost("set")]
        public async Task<IActionResult> Set(string key, string value)
        {
            await _redisBLL.SetData(key, value);
            return Ok("Data stored in Redis");
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get(string key)
        {
            var value = await _redisBLL.GetData(key);
            return Ok(value);
        }
>>>>>>> feature/Redis
    }
}
