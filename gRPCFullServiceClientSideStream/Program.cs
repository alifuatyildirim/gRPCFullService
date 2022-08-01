using Grpc.Core;
using Grpc.Net.Client;
using gRPCFullServiceOrderClient;
using System;
using System.Threading.Tasks;

namespace gRPCFullServiceClientSideStream
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Order.OrderClient(channel);
             
            var reply = client.GetOrdersClientStream(deadline:DateTime.UtcNow.AddSeconds(10));
            try
            {
                for (int i = 1; i < 5; i++)
                {
                    await reply.RequestStream.WriteAsync(new OrderRequest { Id = i });
                }
                await reply.RequestStream.CompleteAsync();
                var res = await reply;
                Print(res);
            }
            catch (RpcException e) when (e.Status.StatusCode == StatusCode.Cancelled)
            {
                Console.WriteLine("Deadline exceeded!");
            }
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
