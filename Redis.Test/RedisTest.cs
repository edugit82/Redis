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
            List<string?> fieldValue = new List<string?>();
            _redisExample.HashesExample(ref fieldValue);
            
            fieldValue.ForEach(a => { 
                if (a != null)
                    Debug.WriteLine($"Hash Field Value: {a}");
            });            
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
            Debug.WriteLine("");
            
            Test01();
            Debug.WriteLine("");
            
            Test02();
            Debug.WriteLine("");
            
            Test03();
            Debug.WriteLine("");
        }
    }
}