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
            ConfigurationOptions option = new ConfigurationOptions();
            option.EndPoints.Add("192.168.16.249", 6379);
            option.Password = "wochu123";

            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(option);
            IDatabase db = redis.GetDatabase();
            string value = "abcdefg";
            db.StringSet("mykey", value);

            Console.WriteLine(db.StringGet("mykey"));

            Console.ReadLine();
        }
    }
}