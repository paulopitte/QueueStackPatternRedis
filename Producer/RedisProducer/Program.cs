using StackExchange.Redis;
namespace RedisProducer;
class Program
{
    static void Main(string[] args)
    {

        var conn = ConnectionMultiplexer.Connect("127.0.0.1:6379");
        var database = conn.GetDatabase();

        var key = "369";
        Console.ForegroundColor = ConsoleColor.Green;

        for (var index = 1; index < 100; index++)
        {
            database.ListLeftPush($"{key}", " order: " + index + ", value: 10000}");
            Console.WriteLine($"{DateTime.UtcNow:o} ==> published {index}");
        }

        Console.WriteLine($"{DateTime.UtcNow:o} ===========> end");
    }
}
