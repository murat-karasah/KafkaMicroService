using Confluent.Kafka;
 
ConsumerConfig config = new()
{
    GroupId = "exampleserver.dbo.buyEntities",
    BootstrapServers = "localhost:29092",
    AutoOffsetReset = AutoOffsetReset.Earliest,
 
};
 
using IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(config).Build();
consumer.Subscribe("exampleserver.dbo.buyEntities");
 
CancellationTokenSource source = new CancellationTokenSource();
Console.CancelKeyPress += (_, e) =>
{
    e.Cancel = true;
    source.Cancel();
};
while (true)
{
    ConsumeResult<Ignore, string> result = consumer.Consume(source.Token);
    Console.WriteLine($"Topic Name : {result.TopicPartitionOffset}");
};

