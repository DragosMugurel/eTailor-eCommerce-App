using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using BusinessLayer.CoreServices.Interfaces;
namespace BusinessLayer.CoreServices
{
    public class MemoryCacheService : ICache
    {
        private readonly int _cacheTime = 60;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cacheTime">The life time in minutes.</param>
        public MemoryCacheService(int cacheTime = 60)
        {
            _cacheTime = cacheTime;
        }

        protected ObjectCache Cache
        {
            get { return MemoryCache.Default; }
        }

        /// <summary>
        /// Gets or sets the value associated with the specified key.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="key">The key of the value to get.</param>
        /// <returns>The value associated with the specified key.</returns>
        public T Get<T>(string key)
        {
            //the objects are kept in the cache as bytes
            //this avoids changing the object from cache involuntarily after saving it or after retrieving it
            BinaryFormatter deserializer = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream((byte[])Cache[key]))
            {
                return (T)deserializer.Deserialize(memStream);
            }
        }

        /// <summary>
        /// Adds the specified key and object to the cache.
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="objectData">Data</param>
        /// <param name="cacheTime">Cache time</param>
        public void Set(string key, object objectData, int? cacheTime = null)
        {
            if (objectData == null)
            {
                return;
            }

            var policy = new CacheItemPolicy();

            if (!cacheTime.HasValue)
            {
                cacheTime = _cacheTime;
            }

            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime.Value);

            BinaryFormatter serializer = new BinaryFormatter();
            using (MemoryStream memStream = new MemoryStream())
            {
                serializer.Serialize(memStream, objectData);
                Cache.Add(new CacheItem(key, memStream.ToArray()), policy);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the value associated with the specified key is cached
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public bool IsSet(string key)
        {
            return Cache.Contains(key);
        }

        /// <summary>
        /// Removes the value with the specified key from the cache
        /// </summary>
        /// <param name="key">/key</param>
        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            foreach (var item in Cache)
            {
                if (item.Key.StartsWith(pattern))
                {
                    Remove(item.Key);
                }
            }
        }

        /// <summary>
        /// Clear all cache data
        /// </summary>
        public void Clear()
        {
            foreach (var item in Cache)
            {
                Remove(item.Key);
            }
        }
    }
}
