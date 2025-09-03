using StackExchange.Redis;

namespace Redis
{
    public class RedisExample
    {
        //Monte Redis server em um container Docker
        
        //Monta o container Docker
        //docker run -d   --name redis_server  -p 6379:6379 -e REDIS_ARGS="--bind 0.0.0.0" redis:latest

        //Crie ACL USER
        //ACL SETUSER eduardocorrea82_redis on >bO7#sL1@  +@all ~*

        // Connect to the Redis server        
        ConnectionMultiplexer redis;
        // Get a reference to the Redis database
        IDatabase db;
        public RedisExample()
        {
            ConfigurationOptions configurationOptions = new ConfigurationOptions
            {
                EndPoints = { "68.211.177.39:6379" },
                User = "eduardocorrea82_redis", // if applicable
                Password = "bO7#sL1@", // if applicable                
                AbortOnConnectFail = false
            };

            //this.redis = ConnectionMultiplexer.Connect("20.119.73.246:6379,abortConnect=false,user=eduardocorrea82_redis,password=bO7#sL1@");
            this.redis = ConnectionMultiplexer.Connect(configurationOptions);
            this.db = redis.GetDatabase();
        }
        public void KeyValueExample(ref string? value)
        {            
            // Set a key-value pair
            db.StringSet("mykey", "Hello, Redis!");
            // Retrieve a value by key
            value = db.StringGet("mykey");            
        }
        public void HashesExample(ref string? fieldValue)
        {            
            // Create a Redis Hash
            HashEntry[] hashEntries = new HashEntry[]
            {
                new HashEntry("field1", "value1"),
                new HashEntry("field2", "value2")
            };
            db.HashSet("myhash", hashEntries);
            // Retrieve a specific field from the Hash
            fieldValue = db.HashGet("myhash", "field1");
        }
        public void ListsExample(ref RedisValue[] listItems) 
        {
            // Add items to a Redis List
            db.ListLeftPush("mylist", "item1");
            db.ListLeftPush("mylist", "item2");
            // Retrieve all items from the List
            listItems = db.ListRange("mylist");
        }
    }
}
