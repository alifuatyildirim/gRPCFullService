using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using gRPCFullServiceOrderClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace gRPCFullServiceServerSideStream
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Order.OrderClient(channel);
            var tokenSource = new CancellationTokenSource();
            var n = 0;
            Empty req = new Empty();
            var reply = client.GetOrderServerStream(req);
            try
            {
                await foreach (var response in reply.ResponseStream.ReadAllAsync(tokenSource.Token)) 
                {
                    Print(response);
                    if (++n == 5)
                    {
                        tokenSource.Cancel();
                    }
                }
            }
            catch (RpcException e) when (e.Status.StatusCode==StatusCode.Cancelled)
            {
                Console.WriteLine("Stremain was cancelled from the client!");
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
