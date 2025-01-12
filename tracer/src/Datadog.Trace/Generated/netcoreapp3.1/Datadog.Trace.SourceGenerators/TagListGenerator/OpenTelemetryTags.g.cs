﻿// <copyright company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
// <auto-generated/>

#nullable enable

using Datadog.Trace.Processors;
using Datadog.Trace.Tagging;
using System;

namespace Datadog.Trace.Tagging
{
    partial class OpenTelemetryTags
    {
        // SpanKindBytes = MessagePack.Serialize("span.kind");
#if NETCOREAPP
        private static ReadOnlySpan<byte> SpanKindBytes => new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#else
        private static readonly byte[] SpanKindBytes = new byte[] { 169, 115, 112, 97, 110, 46, 107, 105, 110, 100 };
#endif
        // HttpRequestMethodBytes = MessagePack.Serialize("http.request.method");
#if NETCOREAPP
        private static ReadOnlySpan<byte> HttpRequestMethodBytes => new byte[] { 179, 104, 116, 116, 112, 46, 114, 101, 113, 117, 101, 115, 116, 46, 109, 101, 116, 104, 111, 100 };
#else
        private static readonly byte[] HttpRequestMethodBytes = new byte[] { 179, 104, 116, 116, 112, 46, 114, 101, 113, 117, 101, 115, 116, 46, 109, 101, 116, 104, 111, 100 };
#endif
        // DbSystemBytes = MessagePack.Serialize("db.system");
#if NETCOREAPP
        private static ReadOnlySpan<byte> DbSystemBytes => new byte[] { 169, 100, 98, 46, 115, 121, 115, 116, 101, 109 };
#else
        private static readonly byte[] DbSystemBytes = new byte[] { 169, 100, 98, 46, 115, 121, 115, 116, 101, 109 };
#endif
        // MessagingSystemBytes = MessagePack.Serialize("messaging.system");
#if NETCOREAPP
        private static ReadOnlySpan<byte> MessagingSystemBytes => new byte[] { 176, 109, 101, 115, 115, 97, 103, 105, 110, 103, 46, 115, 121, 115, 116, 101, 109 };
#else
        private static readonly byte[] MessagingSystemBytes = new byte[] { 176, 109, 101, 115, 115, 97, 103, 105, 110, 103, 46, 115, 121, 115, 116, 101, 109 };
#endif
        // MessagingOperationBytes = MessagePack.Serialize("messaging.operation");
#if NETCOREAPP
        private static ReadOnlySpan<byte> MessagingOperationBytes => new byte[] { 179, 109, 101, 115, 115, 97, 103, 105, 110, 103, 46, 111, 112, 101, 114, 97, 116, 105, 111, 110 };
#else
        private static readonly byte[] MessagingOperationBytes = new byte[] { 179, 109, 101, 115, 115, 97, 103, 105, 110, 103, 46, 111, 112, 101, 114, 97, 116, 105, 111, 110 };
#endif
        // RpcSystemBytes = MessagePack.Serialize("rpc.system");
#if NETCOREAPP
        private static ReadOnlySpan<byte> RpcSystemBytes => new byte[] { 170, 114, 112, 99, 46, 115, 121, 115, 116, 101, 109 };
#else
        private static readonly byte[] RpcSystemBytes = new byte[] { 170, 114, 112, 99, 46, 115, 121, 115, 116, 101, 109 };
#endif
        // RpcServiceBytes = MessagePack.Serialize("rpc.service");
#if NETCOREAPP
        private static ReadOnlySpan<byte> RpcServiceBytes => new byte[] { 171, 114, 112, 99, 46, 115, 101, 114, 118, 105, 99, 101 };
#else
        private static readonly byte[] RpcServiceBytes = new byte[] { 171, 114, 112, 99, 46, 115, 101, 114, 118, 105, 99, 101 };
#endif
        // FaasInvokedProviderBytes = MessagePack.Serialize("faas.invoked_provider");
#if NETCOREAPP
        private static ReadOnlySpan<byte> FaasInvokedProviderBytes => new byte[] { 181, 102, 97, 97, 115, 46, 105, 110, 118, 111, 107, 101, 100, 95, 112, 114, 111, 118, 105, 100, 101, 114 };
#else
        private static readonly byte[] FaasInvokedProviderBytes = new byte[] { 181, 102, 97, 97, 115, 46, 105, 110, 118, 111, 107, 101, 100, 95, 112, 114, 111, 118, 105, 100, 101, 114 };
#endif
        // FaasInvokedNameBytes = MessagePack.Serialize("faas.invoked_name");
#if NETCOREAPP
        private static ReadOnlySpan<byte> FaasInvokedNameBytes => new byte[] { 177, 102, 97, 97, 115, 46, 105, 110, 118, 111, 107, 101, 100, 95, 110, 97, 109, 101 };
#else
        private static readonly byte[] FaasInvokedNameBytes = new byte[] { 177, 102, 97, 97, 115, 46, 105, 110, 118, 111, 107, 101, 100, 95, 110, 97, 109, 101 };
#endif
        // FaasTriggerBytes = MessagePack.Serialize("faas.trigger");
#if NETCOREAPP
        private static ReadOnlySpan<byte> FaasTriggerBytes => new byte[] { 172, 102, 97, 97, 115, 46, 116, 114, 105, 103, 103, 101, 114 };
#else
        private static readonly byte[] FaasTriggerBytes = new byte[] { 172, 102, 97, 97, 115, 46, 116, 114, 105, 103, 103, 101, 114 };
#endif
        // GraphQlOperationTypeBytes = MessagePack.Serialize("graphql.operation.type");
#if NETCOREAPP
        private static ReadOnlySpan<byte> GraphQlOperationTypeBytes => new byte[] { 182, 103, 114, 97, 112, 104, 113, 108, 46, 111, 112, 101, 114, 97, 116, 105, 111, 110, 46, 116, 121, 112, 101 };
#else
        private static readonly byte[] GraphQlOperationTypeBytes = new byte[] { 182, 103, 114, 97, 112, 104, 113, 108, 46, 111, 112, 101, 114, 97, 116, 105, 111, 110, 46, 116, 121, 112, 101 };
#endif
        // NetworkProtocolNameBytes = MessagePack.Serialize("network.protocol.name");
#if NETCOREAPP
        private static ReadOnlySpan<byte> NetworkProtocolNameBytes => new byte[] { 181, 110, 101, 116, 119, 111, 114, 107, 46, 112, 114, 111, 116, 111, 99, 111, 108, 46, 110, 97, 109, 101 };
#else
        private static readonly byte[] NetworkProtocolNameBytes = new byte[] { 181, 110, 101, 116, 119, 111, 114, 107, 46, 112, 114, 111, 116, 111, 99, 111, 108, 46, 110, 97, 109, 101 };
#endif

        public override string? GetTag(string key)
        {
            return key switch
            {
                "span.kind" => SpanKind,
                "http.request.method" => HttpRequestMethod,
                "db.system" => DbSystem,
                "messaging.system" => MessagingSystem,
                "messaging.operation" => MessagingOperation,
                "rpc.system" => RpcSystem,
                "rpc.service" => RpcService,
                "faas.invoked_provider" => FaasInvokedProvider,
                "faas.invoked_name" => FaasInvokedName,
                "faas.trigger" => FaasTrigger,
                "graphql.operation.type" => GraphQlOperationType,
                "network.protocol.name" => NetworkProtocolName,
                _ => base.GetTag(key),
            };
        }

        public override void SetTag(string key, string value)
        {
            switch(key)
            {
                case "span.kind": 
                    SpanKind = value;
                    break;
                case "http.request.method": 
                    HttpRequestMethod = value;
                    break;
                case "db.system": 
                    DbSystem = value;
                    break;
                case "messaging.system": 
                    MessagingSystem = value;
                    break;
                case "messaging.operation": 
                    MessagingOperation = value;
                    break;
                case "rpc.system": 
                    RpcSystem = value;
                    break;
                case "rpc.service": 
                    RpcService = value;
                    break;
                case "faas.invoked_provider": 
                    FaasInvokedProvider = value;
                    break;
                case "faas.invoked_name": 
                    FaasInvokedName = value;
                    break;
                case "faas.trigger": 
                    FaasTrigger = value;
                    break;
                case "graphql.operation.type": 
                    GraphQlOperationType = value;
                    break;
                case "network.protocol.name": 
                    NetworkProtocolName = value;
                    break;
                default: 
                    base.SetTag(key, value);
                    break;
            }
        }

        public override void EnumerateTags<TProcessor>(ref TProcessor processor)
        {
            if (SpanKind is not null)
            {
                processor.Process(new TagItem<string>("span.kind", SpanKind, SpanKindBytes));
            }

            if (HttpRequestMethod is not null)
            {
                processor.Process(new TagItem<string>("http.request.method", HttpRequestMethod, HttpRequestMethodBytes));
            }

            if (DbSystem is not null)
            {
                processor.Process(new TagItem<string>("db.system", DbSystem, DbSystemBytes));
            }

            if (MessagingSystem is not null)
            {
                processor.Process(new TagItem<string>("messaging.system", MessagingSystem, MessagingSystemBytes));
            }

            if (MessagingOperation is not null)
            {
                processor.Process(new TagItem<string>("messaging.operation", MessagingOperation, MessagingOperationBytes));
            }

            if (RpcSystem is not null)
            {
                processor.Process(new TagItem<string>("rpc.system", RpcSystem, RpcSystemBytes));
            }

            if (RpcService is not null)
            {
                processor.Process(new TagItem<string>("rpc.service", RpcService, RpcServiceBytes));
            }

            if (FaasInvokedProvider is not null)
            {
                processor.Process(new TagItem<string>("faas.invoked_provider", FaasInvokedProvider, FaasInvokedProviderBytes));
            }

            if (FaasInvokedName is not null)
            {
                processor.Process(new TagItem<string>("faas.invoked_name", FaasInvokedName, FaasInvokedNameBytes));
            }

            if (FaasTrigger is not null)
            {
                processor.Process(new TagItem<string>("faas.trigger", FaasTrigger, FaasTriggerBytes));
            }

            if (GraphQlOperationType is not null)
            {
                processor.Process(new TagItem<string>("graphql.operation.type", GraphQlOperationType, GraphQlOperationTypeBytes));
            }

            if (NetworkProtocolName is not null)
            {
                processor.Process(new TagItem<string>("network.protocol.name", NetworkProtocolName, NetworkProtocolNameBytes));
            }

            base.EnumerateTags(ref processor);
        }

        protected override void WriteAdditionalTags(System.Text.StringBuilder sb)
        {
            if (SpanKind is not null)
            {
                sb.Append("span.kind (tag):")
                  .Append(SpanKind)
                  .Append(',');
            }

            if (HttpRequestMethod is not null)
            {
                sb.Append("http.request.method (tag):")
                  .Append(HttpRequestMethod)
                  .Append(',');
            }

            if (DbSystem is not null)
            {
                sb.Append("db.system (tag):")
                  .Append(DbSystem)
                  .Append(',');
            }

            if (MessagingSystem is not null)
            {
                sb.Append("messaging.system (tag):")
                  .Append(MessagingSystem)
                  .Append(',');
            }

            if (MessagingOperation is not null)
            {
                sb.Append("messaging.operation (tag):")
                  .Append(MessagingOperation)
                  .Append(',');
            }

            if (RpcSystem is not null)
            {
                sb.Append("rpc.system (tag):")
                  .Append(RpcSystem)
                  .Append(',');
            }

            if (RpcService is not null)
            {
                sb.Append("rpc.service (tag):")
                  .Append(RpcService)
                  .Append(',');
            }

            if (FaasInvokedProvider is not null)
            {
                sb.Append("faas.invoked_provider (tag):")
                  .Append(FaasInvokedProvider)
                  .Append(',');
            }

            if (FaasInvokedName is not null)
            {
                sb.Append("faas.invoked_name (tag):")
                  .Append(FaasInvokedName)
                  .Append(',');
            }

            if (FaasTrigger is not null)
            {
                sb.Append("faas.trigger (tag):")
                  .Append(FaasTrigger)
                  .Append(',');
            }

            if (GraphQlOperationType is not null)
            {
                sb.Append("graphql.operation.type (tag):")
                  .Append(GraphQlOperationType)
                  .Append(',');
            }

            if (NetworkProtocolName is not null)
            {
                sb.Append("network.protocol.name (tag):")
                  .Append(NetworkProtocolName)
                  .Append(',');
            }

            base.WriteAdditionalTags(sb);
        }
    }
}
