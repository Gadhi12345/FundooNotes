using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Interface
{
    public interface IRedisDAL
    {
        Task SetData(string key, string value);
        Task<string> GetData(string key);
    }
}
