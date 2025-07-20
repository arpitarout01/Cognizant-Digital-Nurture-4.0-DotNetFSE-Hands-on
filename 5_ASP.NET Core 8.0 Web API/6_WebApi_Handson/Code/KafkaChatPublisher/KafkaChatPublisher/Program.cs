using Confluent.Kafka;

Console.WriteLine("Enter your name:");
string username = Console.ReadLine();

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("Start typing messages (Ctrl+C to exit):");
while (true)
{
    string message = Console.ReadLine();
    var result = await producer.ProduceAsync("chat-topic", new Message<Null, string>
    {
        Value = $"{username}: {message}"
    });

    Console.WriteLine($"[Sent] {result.Value}");
}
