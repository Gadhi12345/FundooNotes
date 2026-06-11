using BussinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Services
{
    public class RedisBLL : IRedisBLL
    {
        private readonly IRedisDAL _redisDAL;

        public RedisBLL(IRedisDAL redisDAL)
        {
            _redisDAL = redisDAL;
        }

        public async Task SetData(string key, string value)
        {
            await _redisDAL.SetData(key, value);
        }

        public async Task<string> GetData(string key)
        {
            return await _redisDAL.GetData(key);
        }
    }
}
