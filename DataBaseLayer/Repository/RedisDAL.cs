using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using Microsoft.EntityFrameworkCore.Storage;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public class RedisDAL : IRedisDAL
    {
        private readonly StackExchange.Redis.IDatabase _db;

        public RedisDAL(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task SetData(string key, string value)
        {
            await _db.StringSetAsync(key, value);
        }

        public async Task<string> GetData(string key)
        {
            return (await _db.StringGetAsync(key)).ToString();
        }
    }
}
