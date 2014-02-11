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
        TimeSpan m_cacheLife;

        public TimeCache(TimeSpan cacheLifeTime)
        {
            m_cacheLife = cacheLifeTime;
        }

        public T Get(string key, Func<T> getValue)
        {
            T value = m_cache[key] as T;
            if (value == null)
            {
                value = getValue();
                m_cache.Add(key, value, new CacheItemPolicy() { SlidingExpiration = m_cacheLife });
            }
            return value;

        }
    }
}
