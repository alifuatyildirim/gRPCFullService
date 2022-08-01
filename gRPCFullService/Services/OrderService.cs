using Google.Protobuf.Collections;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using gRPCFullServiceOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gRPCFullService.Services
{
    public class OrderService : Order.OrderBase
    {
        public List<OrderC> OrderList { get; set; }
        public List<OrderItem> OrderItemList { get; set; }
        public OrderService()
        {
            OrderList = new List<OrderC>()
            {
                new OrderC()
                {
                    Id = 1,
                    Name="Order -1"
                },
                new OrderC()
                {
                    Id = 2,
                    Name="Order -2"
                },
                new OrderC()
                {
                    Id = 3,
                    Name="Order -3"
                },
                 new OrderC()
                {
                    Id = 4,
                    Name="Order -4"
                }
            };

            OrderItemList = new List<OrderItem>()
            {
                new OrderItem()
                {
                    Id = 1,
                    Name="Order Item -1",
                    OrderCId=1
                },
                new OrderItem()
                {
                    Id = 2,
                    Name="Order Item -2",
                    OrderCId=1
                },
                new OrderItem()
                {
                    Id = 3,
                    Name="Order Item -3",
                    OrderCId=2
                },
                new OrderItem()
                {
                    Id = 4,
                    Name="Order Item -4",
                    OrderCId=3
                }
            };
        }
        public override Task<OrderResponse> GetOrder(OrderRequest request, ServerCallContext context)
        {
            OrderResponse response = new OrderResponse();
            var order = OrderList.FirstOrDefault(x => x.Id == request.Id);
            var orderItems = OrderItemList.Where(x => x.OrderCId == request.Id);
            var random = new Random();
            response.Orders.Add(new Orders
            {
                Id = order.Id,
                Name = order.Name,
                OrderItems = {  orderItems.Select(q=>new OrderItems
                {
                    Count = q.Count,
                    Id = q.Id,
                    OrderId=order.Id,
                    Name=q.Name,
                })
                }
            });
            return Task.FromResult(response);
        }
        public override async Task<OrderResponse> GetOrdersClientStream(IAsyncStreamReader<OrderRequest> requestStream, ServerCallContext context)
        {
            OrderResponse orderResponse = new OrderResponse();
            await foreach (var message in requestStream.ReadAllAsync())
            {
                var order = OrderList.FirstOrDefault(x => x.Id == message.Id);
                var orderItems = OrderItemList.Where(x => x.OrderCId == message.Id);
                orderResponse.Orders.Add(new Orders
                {
                    Id = order.Id,
                    Name = order.Name,
                    OrderItems = {  orderItems.Select(q=>new OrderItems
                        {
                            Count = q.Count,
                            Id = q.Id,
                            OrderId=order.Id,
                            Name=q.Name,
                        })
                    }
                });
                await Task.Delay(1000);
            }
            return orderResponse;
        }
        public override async Task GetOrderServerStream(Empty request, IServerStreamWriter<OrderResponse> responseStream, ServerCallContext context)
        {
            OrderResponse orderResponse;

            foreach (var order in OrderList)
            {
                orderResponse = new OrderResponse();
                var orderItems = OrderItemList.Where(x => x.OrderCId == order.Id);
                orderResponse.Orders.Add(new Orders
                {
                    Id = order.Id,
                    Name = order.Name,
                    OrderItems = {  orderItems.Select(q=>new OrderItems
                        {
                            Count = q.Count,
                            Id = q.Id,
                            OrderId=order.Id,
                            Name=q.Name,
                        })
                }
                });
                await responseStream.WriteAsync(orderResponse);
                await Task.Delay(1000, context.CancellationToken);
            }
        }
    }
}
