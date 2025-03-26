using StackExchange.Redis;

namespace RedisConsumer;
class Program
{
    static void Main(string[] args)
    {
        var conn = ConnectionMultiplexer.Connect("127.0.0.1:6379");
        var database = conn.GetDatabase();

        var key = "369";
        Console.ForegroundColor = ConsoleColor.Yellow;

        while (true)
        {
            var data = database.ListLeftPop(key);
            Console.WriteLine($"{DateTime.UtcNow:o} => {data}");
            Thread.Sleep(100);
        }

    }
}
