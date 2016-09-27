using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CacheHelper cachehelper = new CacheHelper();
            cachehelper.Get("123");

            Console.ReadLine();
        }
    }

    public class CacheHelper
    {
        private ConfigurationOptions option = new ConfigurationOptions { EndPoints = { { "192.168.16.249", 6379 } }, Password = "wochu123" };

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object Get(string key)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(option);
            IDatabase db = redis.GetDatabase();

            if (db.StringGet(key).IsNullOrEmpty)
            {
                bool bl = db.StringSet(key, "");
            }
            object str = db.StringGet(key);
            return str;
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, string value)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(option);
            IDatabase db = redis.GetDatabase();
            bool bl = db.StringSet(key, value);
            return bl;
        }

        /// <summary>
        /// 添加队列
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public string QueueAdd(string key, string value)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(option);
            IDatabase db = redis.GetDatabase();
            string str = db.StringGet(key);
            db.StringSet(key, value);

            return str;
        }
    }
}
