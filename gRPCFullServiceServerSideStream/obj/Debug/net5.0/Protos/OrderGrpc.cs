// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/order.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace gRPCFullServiceOrderClient {
  public static partial class Order
  {
    static readonly string __ServiceName = "Orderv2.Order";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::gRPCFullServiceOrderClient.OrderRequest> __Marshaller_Orderv2_OrderRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCFullServiceOrderClient.OrderRequest.Parser));
    static readonly grpc::Marshaller<global::gRPCFullServiceOrderClient.OrderResponse> __Marshaller_Orderv2_OrderResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::gRPCFullServiceOrderClient.OrderResponse.Parser));
    static readonly grpc::Marshaller<global::Google.Protobuf.WellKnownTypes.Empty> __Marshaller_google_protobuf_Empty = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Google.Protobuf.WellKnownTypes.Empty.Parser));

    static readonly grpc::Method<global::gRPCFullServiceOrderClient.OrderRequest, global::gRPCFullServiceOrderClient.OrderResponse> __Method_GetOrder = new grpc::Method<global::gRPCFullServiceOrderClient.OrderRequest, global::gRPCFullServiceOrderClient.OrderResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetOrder",
        __Marshaller_Orderv2_OrderRequest,
        __Marshaller_Orderv2_OrderResponse);

    static readonly grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::gRPCFullServiceOrderClient.OrderResponse> __Method_GetOrderServerStream = new grpc::Method<global::Google.Protobuf.WellKnownTypes.Empty, global::gRPCFullServiceOrderClient.OrderResponse>(
        grpc::MethodType.ServerStreaming,
        __ServiceName,
        "GetOrderServerStream",
        __Marshaller_google_protobuf_Empty,
        __Marshaller_Orderv2_OrderResponse);

    static readonly grpc::Method<global::gRPCFullServiceOrderClient.OrderRequest, global::gRPCFullServiceOrderClient.OrderResponse> __Method_GetOrdersClientStream = new grpc::Method<global::gRPCFullServiceOrderClient.OrderRequest, global::gRPCFullServiceOrderClient.OrderResponse>(
        grpc::MethodType.ClientStreaming,
        __ServiceName,
        "GetOrdersClientStream",
        __Marshaller_Orderv2_OrderRequest,
        __Marshaller_Orderv2_OrderResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::gRPCFullServiceOrderClient.OrderReflection.Descriptor.Services[0]; }
    }

    /// <summary>Client for Order</summary>
    public partial class OrderClient : grpc::ClientBase<OrderClient>
    {
      /// <summary>Creates a new client for Order</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public OrderClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for Order that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public OrderClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected OrderClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected OrderClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::gRPCFullServiceOrderClient.OrderResponse GetOrder(global::gRPCFullServiceOrderClient.OrderRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOrder(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::gRPCFullServiceOrderClient.OrderResponse GetOrder(global::gRPCFullServiceOrderClient.OrderRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_GetOrder, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::gRPCFullServiceOrderClient.OrderResponse> GetOrderAsync(global::gRPCFullServiceOrderClient.OrderRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOrderAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::gRPCFullServiceOrderClient.OrderResponse> GetOrderAsync(global::gRPCFullServiceOrderClient.OrderRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_GetOrder, null, options, request);
      }
      public virtual grpc::AsyncServerStreamingCall<global::gRPCFullServiceOrderClient.OrderResponse> GetOrderServerStream(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOrderServerStream(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncServerStreamingCall<global::gRPCFullServiceOrderClient.OrderResponse> GetOrderServerStream(global::Google.Protobuf.WellKnownTypes.Empty request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncServerStreamingCall(__Method_GetOrderServerStream, null, options, request);
      }
      public virtual grpc::AsyncClientStreamingCall<global::gRPCFullServiceOrderClient.OrderRequest, global::gRPCFullServiceOrderClient.OrderResponse> GetOrdersClientStream(grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return GetOrdersClientStream(new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncClientStreamingCall<global::gRPCFullServiceOrderClient.OrderRequest, global::gRPCFullServiceOrderClient.OrderResponse> GetOrdersClientStream(grpc::CallOptions options)
      {
        return CallInvoker.AsyncClientStreamingCall(__Method_GetOrdersClientStream, null, options);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override OrderClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new OrderClient(configuration);
      }
    }

  }
}
#endregion
