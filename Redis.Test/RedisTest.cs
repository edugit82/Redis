namespace Redis.Test
{
    public class RedisTest
    {
        private RedisExample _redisExample = new RedisExample();

        [Fact]
        public void Test01()
        {
            _redisExample.KeyValueExample();
        }
        [Fact]
        public void Test02()
        {
            _redisExample.HashesExample();
        }
        [Fact]
        public void Test03()
        {
            _redisExample.ListsExample();
        }
    }
}