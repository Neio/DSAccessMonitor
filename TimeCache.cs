using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace PropertyChange
{
    public interface ICache<T>
    {
        T Get(string key, Func<T> getValue);
    }

    public class TimeCache<T> : ICache<T> where T : class
    {
        public MemoryCache m_cache = new MemoryCache(Guid.NewGuid().ToString());
        long m_cacheLife;

        public TimeCache(TimeSpan cacheLifeTime)
        {
            m_cacheLife = (long)cacheLifeTime.TotalSeconds;
        }
        public T Get(string key, Func<T> getValue)
        {
            var cache = m_cache[key];
            if (cache != null)
            {
                var value = cache as T;
                if (value != null)
                {
                    return value;
                }
            }

            var v = getValue();
            m_cache.Add(key, v, DateTimeOffset.Now.AddSeconds(m_cacheLife));
            return v;

        }
    }
}
