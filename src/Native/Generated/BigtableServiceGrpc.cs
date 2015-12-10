// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: google/bigtable/v1/bigtable_service.proto
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace Google.Bigtable.V1 {
  public static class BigtableService
  {
    static readonly string __ServiceName = "google.bigtable.v1.BigtableService";

    static readonly Marshaller<global::Google.Bigtable.V1.ReadRowsRequest> __Marshaller_ReadRowsRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.ReadRowsRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.ReadRowsResponse> __Marshaller_ReadRowsResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.ReadRowsResponse.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.SampleRowKeysRequest> __Marshaller_SampleRowKeysRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.SampleRowKeysRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.SampleRowKeysResponse> __Marshaller_SampleRowKeysResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.SampleRowKeysResponse.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.MutateRowRequest> __Marshaller_MutateRowRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.MutateRowRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Protobuf.Empty> __Marshaller_Empty = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Protobuf.Empty.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.CheckAndMutateRowRequest> __Marshaller_CheckAndMutateRowRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.CheckAndMutateRowRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.CheckAndMutateRowResponse> __Marshaller_CheckAndMutateRowResponse = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.CheckAndMutateRowResponse.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.ReadModifyWriteRowRequest> __Marshaller_ReadModifyWriteRowRequest = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.ReadModifyWriteRowRequest.Parser.ParseFrom);
    static readonly Marshaller<global::Google.Bigtable.V1.Row> __Marshaller_Row = Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::Google.Bigtable.V1.Row.Parser.ParseFrom);

    static readonly Method<global::Google.Bigtable.V1.ReadRowsRequest, global::Google.Bigtable.V1.ReadRowsResponse> __Method_ReadRows = new Method<global::Google.Bigtable.V1.ReadRowsRequest, global::Google.Bigtable.V1.ReadRowsResponse>(
        MethodType.ServerStreaming,
        __ServiceName,
        "ReadRows",
        __Marshaller_ReadRowsRequest,
        __Marshaller_ReadRowsResponse);

    static readonly Method<global::Google.Bigtable.V1.SampleRowKeysRequest, global::Google.Bigtable.V1.SampleRowKeysResponse> __Method_SampleRowKeys = new Method<global::Google.Bigtable.V1.SampleRowKeysRequest, global::Google.Bigtable.V1.SampleRowKeysResponse>(
        MethodType.ServerStreaming,
        __ServiceName,
        "SampleRowKeys",
        __Marshaller_SampleRowKeysRequest,
        __Marshaller_SampleRowKeysResponse);

    static readonly Method<global::Google.Bigtable.V1.MutateRowRequest, global::Google.Protobuf.Empty> __Method_MutateRow = new Method<global::Google.Bigtable.V1.MutateRowRequest, global::Google.Protobuf.Empty>(
        MethodType.Unary,
        __ServiceName,
        "MutateRow",
        __Marshaller_MutateRowRequest,
        __Marshaller_Empty);

    static readonly Method<global::Google.Bigtable.V1.CheckAndMutateRowRequest, global::Google.Bigtable.V1.CheckAndMutateRowResponse> __Method_CheckAndMutateRow = new Method<global::Google.Bigtable.V1.CheckAndMutateRowRequest, global::Google.Bigtable.V1.CheckAndMutateRowResponse>(
        MethodType.Unary,
        __ServiceName,
        "CheckAndMutateRow",
        __Marshaller_CheckAndMutateRowRequest,
        __Marshaller_CheckAndMutateRowResponse);

    static readonly Method<global::Google.Bigtable.V1.ReadModifyWriteRowRequest, global::Google.Bigtable.V1.Row> __Method_ReadModifyWriteRow = new Method<global::Google.Bigtable.V1.ReadModifyWriteRowRequest, global::Google.Bigtable.V1.Row>(
        MethodType.Unary,
        __ServiceName,
        "ReadModifyWriteRow",
        __Marshaller_ReadModifyWriteRowRequest,
        __Marshaller_Row);

    // service descriptor
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Google.Bigtable.V1.Proto.BigtableService.Descriptor.Services[0]; }
    }

    // client interface
    public interface IBigtableServiceClient
    {
      AsyncServerStreamingCall<global::Google.Bigtable.V1.ReadRowsResponse> ReadRows(global::Google.Bigtable.V1.ReadRowsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncServerStreamingCall<global::Google.Bigtable.V1.ReadRowsResponse> ReadRows(global::Google.Bigtable.V1.ReadRowsRequest request, CallOptions options);
      AsyncServerStreamingCall<global::Google.Bigtable.V1.SampleRowKeysResponse> SampleRowKeys(global::Google.Bigtable.V1.SampleRowKeysRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncServerStreamingCall<global::Google.Bigtable.V1.SampleRowKeysResponse> SampleRowKeys(global::Google.Bigtable.V1.SampleRowKeysRequest request, CallOptions options);
      global::Google.Protobuf.Empty MutateRow(global::Google.Bigtable.V1.MutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::Google.Protobuf.Empty MutateRow(global::Google.Bigtable.V1.MutateRowRequest request, CallOptions options);
      AsyncUnaryCall<global::Google.Protobuf.Empty> MutateRowAsync(global::Google.Bigtable.V1.MutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::Google.Protobuf.Empty> MutateRowAsync(global::Google.Bigtable.V1.MutateRowRequest request, CallOptions options);
      global::Google.Bigtable.V1.CheckAndMutateRowResponse CheckAndMutateRow(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::Google.Bigtable.V1.CheckAndMutateRowResponse CheckAndMutateRow(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, CallOptions options);
      AsyncUnaryCall<global::Google.Bigtable.V1.CheckAndMutateRowResponse> CheckAndMutateRowAsync(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::Google.Bigtable.V1.CheckAndMutateRowResponse> CheckAndMutateRowAsync(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, CallOptions options);
      global::Google.Bigtable.V1.Row ReadModifyWriteRow(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      global::Google.Bigtable.V1.Row ReadModifyWriteRow(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, CallOptions options);
      AsyncUnaryCall<global::Google.Bigtable.V1.Row> ReadModifyWriteRowAsync(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken));
      AsyncUnaryCall<global::Google.Bigtable.V1.Row> ReadModifyWriteRowAsync(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, CallOptions options);
    }

    // server-side interface
    public interface IBigtableService
    {
      Task ReadRows(global::Google.Bigtable.V1.ReadRowsRequest request, IServerStreamWriter<global::Google.Bigtable.V1.ReadRowsResponse> responseStream, ServerCallContext context);
      Task SampleRowKeys(global::Google.Bigtable.V1.SampleRowKeysRequest request, IServerStreamWriter<global::Google.Bigtable.V1.SampleRowKeysResponse> responseStream, ServerCallContext context);
      Task<global::Google.Protobuf.Empty> MutateRow(global::Google.Bigtable.V1.MutateRowRequest request, ServerCallContext context);
      Task<global::Google.Bigtable.V1.CheckAndMutateRowResponse> CheckAndMutateRow(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, ServerCallContext context);
      Task<global::Google.Bigtable.V1.Row> ReadModifyWriteRow(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, ServerCallContext context);
    }

    // client stub
    public class BigtableServiceClient : ClientBase, IBigtableServiceClient
    {
      public BigtableServiceClient(Channel channel) : base(channel)
      {
      }
      public AsyncServerStreamingCall<global::Google.Bigtable.V1.ReadRowsResponse> ReadRows(global::Google.Bigtable.V1.ReadRowsRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_ReadRows, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncServerStreamingCall(call, request);
      }
      public AsyncServerStreamingCall<global::Google.Bigtable.V1.ReadRowsResponse> ReadRows(global::Google.Bigtable.V1.ReadRowsRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_ReadRows, options);
        return Calls.AsyncServerStreamingCall(call, request);
      }
      public AsyncServerStreamingCall<global::Google.Bigtable.V1.SampleRowKeysResponse> SampleRowKeys(global::Google.Bigtable.V1.SampleRowKeysRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_SampleRowKeys, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncServerStreamingCall(call, request);
      }
      public AsyncServerStreamingCall<global::Google.Bigtable.V1.SampleRowKeysResponse> SampleRowKeys(global::Google.Bigtable.V1.SampleRowKeysRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_SampleRowKeys, options);
        return Calls.AsyncServerStreamingCall(call, request);
      }
      public global::Google.Protobuf.Empty MutateRow(global::Google.Bigtable.V1.MutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_MutateRow, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::Google.Protobuf.Empty MutateRow(global::Google.Bigtable.V1.MutateRowRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_MutateRow, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::Google.Protobuf.Empty> MutateRowAsync(global::Google.Bigtable.V1.MutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_MutateRow, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::Google.Protobuf.Empty> MutateRowAsync(global::Google.Bigtable.V1.MutateRowRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_MutateRow, options);
        return Calls.AsyncUnaryCall(call, request);
      }
      public global::Google.Bigtable.V1.CheckAndMutateRowResponse CheckAndMutateRow(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_CheckAndMutateRow, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::Google.Bigtable.V1.CheckAndMutateRowResponse CheckAndMutateRow(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_CheckAndMutateRow, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::Google.Bigtable.V1.CheckAndMutateRowResponse> CheckAndMutateRowAsync(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_CheckAndMutateRow, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::Google.Bigtable.V1.CheckAndMutateRowResponse> CheckAndMutateRowAsync(global::Google.Bigtable.V1.CheckAndMutateRowRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_CheckAndMutateRow, options);
        return Calls.AsyncUnaryCall(call, request);
      }
      public global::Google.Bigtable.V1.Row ReadModifyWriteRow(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_ReadModifyWriteRow, new CallOptions(headers, deadline, cancellationToken));
        return Calls.BlockingUnaryCall(call, request);
      }
      public global::Google.Bigtable.V1.Row ReadModifyWriteRow(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_ReadModifyWriteRow, options);
        return Calls.BlockingUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::Google.Bigtable.V1.Row> ReadModifyWriteRowAsync(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        var call = CreateCall(__Method_ReadModifyWriteRow, new CallOptions(headers, deadline, cancellationToken));
        return Calls.AsyncUnaryCall(call, request);
      }
      public AsyncUnaryCall<global::Google.Bigtable.V1.Row> ReadModifyWriteRowAsync(global::Google.Bigtable.V1.ReadModifyWriteRowRequest request, CallOptions options)
      {
        var call = CreateCall(__Method_ReadModifyWriteRow, options);
        return Calls.AsyncUnaryCall(call, request);
      }
    }

    // creates service definition that can be registered with a server
    public static ServerServiceDefinition BindService(IBigtableService serviceImpl)
    {
      return ServerServiceDefinition.CreateBuilder(__ServiceName)
          .AddMethod(__Method_ReadRows, serviceImpl.ReadRows)
          .AddMethod(__Method_SampleRowKeys, serviceImpl.SampleRowKeys)
          .AddMethod(__Method_MutateRow, serviceImpl.MutateRow)
          .AddMethod(__Method_CheckAndMutateRow, serviceImpl.CheckAndMutateRow)
          .AddMethod(__Method_ReadModifyWriteRow, serviceImpl.ReadModifyWriteRow).Build();
    }

    // creates a new client
    public static BigtableServiceClient NewClient(Channel channel)
    {
      return new BigtableServiceClient(channel);
    }

  }
}
#endregion