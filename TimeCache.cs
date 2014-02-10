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
            T value = m_cache[key] as T ?? getValue();
            m_cache.Set(key, value, DateTimeOffset.Now.AddSeconds(m_cacheLife));
            return value;

        }
    }
}
