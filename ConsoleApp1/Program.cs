using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Confluent.Kafka;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsumerConfig consumerConfig = new()
            {
                GroupId = "exampleserver.exampleschema.exampletable",
                BootstrapServers = "localhost:29092",
                AutoOffsetReset = AutoOffsetReset.Earliest,

            };
            ConsumerConfig config = consumerConfig;

            using IConsumer<Ignore, string> consumer = new ConsumerBuilder<Ignore, string>(config).Build();
            consumer.Subscribe("exampleserver.exampleschema.exampletable");

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
                Console.WriteLine($"Message : {result.Value}");
            }
        }
    }
}
