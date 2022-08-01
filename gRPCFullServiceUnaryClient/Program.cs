using Grpc.Net.Client;
using gRPCFullServiceOrderClient;
using System;
using System.Threading.Tasks;

namespace gRPCFullServiceUnaryClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Order.OrderClient(channel);

            OrderRequest req = new OrderRequest { Id = 1 };
            var reply = await client.GetOrderAsync(req);
            Print(reply);
            Console.ReadLine();
        }
        static void Print(OrderResponse response)
        {
            foreach (var order in response.Orders)
            {
                Console.WriteLine($"Order {order.Id}:");
                foreach (var item in order.OrderItems)
                {
                    Console.WriteLine("Order Details: " + item);
                }
            }
        }
    }
}
