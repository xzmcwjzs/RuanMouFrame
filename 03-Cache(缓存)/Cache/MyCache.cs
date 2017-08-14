using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Cache_缓存_.Cache
{
    public class MyCache : ICache
    {
        private static Dictionary<string, KeyValuePair<object, DateTime>> DATA = new Dictionary<string, KeyValuePair<object, DateTime>>();

        /// <summary>
        /// 被动过期  想主动过期，就启动一个线程不断的扫描
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            if (!this.Contains(key))
            {
                return default(T);
            }
            else
            {
                KeyValuePair<object, DateTime> keyValue = DATA[key];
                if (keyValue.Value < DateTime.Now)
                {
                    this.Remove(key);//过期删除
                    return default(T);
                }
                else
                {
                    return (T)keyValue.Key;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cacheTime">过期分钟数  默认30</param>
        public void Add(string key, object data, int cacheTime = 30)
        {
            DATA[key] = new KeyValuePair<object, DateTime>(data, DateTime.Now.AddMinutes(30));
        }

        public bool Contains(string key)
        {
            return DATA.ContainsKey(key);
        }

        public void Remove(string key)
        {
            if (this.Contains(key))
                DATA.Remove(key);
        }

        public void RemoveAll()
        {
            DATA = new Dictionary<string, KeyValuePair<object, DateTime>>();
        }

        public object this[string key]
        {
            get
            {
                if (this.Contains(key))
                    return DATA[key];
                else return null;
            }
            set
            {
                DATA[key] = new KeyValuePair<object, DateTime>(value, DateTime.Now);
            }
        }

        public int Count
        {
            get { return DATA.Count(); }
        }

    }
}
