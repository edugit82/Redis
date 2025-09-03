using StackExchange.Redis;
using System.Diagnostics;

namespace Redis.Test
{
    public class RedisTest
    {
        private RedisExample _redisExample = new RedisExample();
                
        private void Test01()
        {
            string? value = "";
            _redisExample.KeyValueExample(ref value);
            Debug.WriteLine($"KeyValue: {value}");
        }        
        private void Test02()
        {

            string? fieldValue = "";
            _redisExample.HashesExample(ref fieldValue);
            Debug.WriteLine($"Hash Field Value: {fieldValue}");
        }        
        private void Test03()
        {
            RedisValue[] listItems = new RedisValue[] { };
            _redisExample.ListsExample(ref listItems);

            listItems.ToList().ForEach(item => Debug.WriteLine($"List Item: {item}"));
        }

        [Fact]
        public void RunAll()
        {
            Test01();
            Test02();
            Test03();
        }
    }
}