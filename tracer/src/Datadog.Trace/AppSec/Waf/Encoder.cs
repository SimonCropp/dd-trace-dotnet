// <copyright file="Encoder.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Datadog.Trace.AppSec.Waf.NativeBindings;
using Datadog.Trace.Logging;
using Datadog.Trace.Util;
using Datadog.Trace.Vendors.Newtonsoft.Json.Linq;

namespace Datadog.Trace.AppSec.Waf
{
    internal static class Encoder
    {
        private static readonly IDatadogLogger Log = DatadogLogging.GetLoggerFor(typeof(Encoder));
        private static readonly int ObjectStructSize = Marshal.SizeOf(typeof(DdwafObjectStruct));

        public static ObjType DecodeArgsType(DDWAF_OBJ_TYPE t)
        {
            return t switch
            {
                DDWAF_OBJ_TYPE.DDWAF_OBJ_INVALID => ObjType.Invalid,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_SIGNED => ObjType.SignedNumber,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_UNSIGNED => ObjType.UnsignedNumber,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_STRING => ObjType.String,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_BOOL => ObjType.Bool,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_DOUBLE => ObjType.Double,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_ARRAY => ObjType.Array,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_MAP => ObjType.Map,
                DDWAF_OBJ_TYPE.DDWAF_OBJ_NULL => ObjType.Null,
                _ => throw new Exception($"Invalid DDWAF_INPUT_TYPE {t}")
            };
        }

        private static string TruncateLongString(string s) => s.Length > WafConstants.MaxStringLength ? s.Substring(0, WafConstants.MaxStringLength) : s;

        public static Obj Encode(object o, WafLibraryInvoker wafLibraryInvoker, List<Obj>? argCache = null, bool applySafetyLimits = true) => EncodeInternal(o, argCache, WafConstants.MaxContainerDepth, applySafetyLimits, wafLibraryInvoker);

        private static Obj EncodeUnknownType(object o, WafLibraryInvoker wafLibraryInvoker)
        {
            Log.Warning("Couldn't encode object of unknown type {Type}, falling back to ToString", o.GetType());

            var s = o.ToString() ?? string.Empty;

            return CreateNativeString(s, applyLimits: true, wafLibraryInvoker);
        }

        private static Obj EncodeInternal<T>(T o, List<Obj>? argCache, int remainingDepth, bool applyLimits, WafLibraryInvoker wafLibraryInvoker)
        {
            var value =
                o switch
                {
                    null => CreateNativeNull(wafLibraryInvoker),
                    string s => CreateNativeString(s, applyLimits, wafLibraryInvoker),
                    JValue jv => CreateNativeString(jv.Value?.ToString() ?? string.Empty, applyLimits, wafLibraryInvoker),
                    int i => CreateNativeLong(i, wafLibraryInvoker),
                    uint i => CreateNativeUlong(i, wafLibraryInvoker),
                    long i => CreateNativeLong(i, wafLibraryInvoker),
                    ulong i => CreateNativeUlong(i, wafLibraryInvoker),
                    float i => CreateNativeDouble(i, wafLibraryInvoker),
                    double i => CreateNativeDouble(i, wafLibraryInvoker),
                    decimal i => CreateNativeDouble((double)i, wafLibraryInvoker),
                    bool b => CreateNativeBool(b, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, JToken>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, int>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, uint>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, long>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, float>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, double>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, decimal>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, string>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, object>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, bool>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, List<string>>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, string[]>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, List<double>>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IEnumerable<KeyValuePair<string, double[]>> objDict => EncodeDictionary(objDict, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<JToken> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<string> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<object> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<int> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<float> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<uint> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<long> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<ulong> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<double> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    IList<decimal> objs => EncodeList(objs, argCache, remainingDepth, applyLimits, wafLibraryInvoker),
                    _ => EncodeUnknownType(o, wafLibraryInvoker),
                };

            argCache?.Add(value);

            return value;
        }

        private static Obj EncodeList<T>(IEnumerable<T> objEnumerator, List<Obj>? argCache, int remainingDepth, bool applyLimits, WafLibraryInvoker wafLibraryInvoker)
        {
            var arrNat = wafLibraryInvoker.ObjectArray();

            if (applyLimits && remainingDepth-- <= 0)
            {
                Log.Warning("EncodeList: object graph too deep, truncating nesting {Items}", string.Join(", ", objEnumerator));
                return new Obj(arrNat);
            }

            var count = objEnumerator is IList<object> objs ? objs.Count : objEnumerator.Count();
            if (applyLimits && count > WafConstants.MaxContainerSize)
            {
                Log.Warning<int, int>("EncodeList: list too long, it will be truncated, count: {Count}, MaxMapOrArrayLength {MaxMapOrArrayLength}", count, WafConstants.MaxContainerSize);
                objEnumerator = objEnumerator.Take(WafConstants.MaxContainerSize);
            }

            foreach (var o in objEnumerator)
            {
                var value = EncodeInternal(o, argCache, remainingDepth, applyLimits, wafLibraryInvoker);
                wafLibraryInvoker.ObjectArrayAdd(arrNat, value.RawPtr);
            }

            return new Obj(arrNat);
        }

        private static Obj EncodeDictionary<T>(IEnumerable<KeyValuePair<string, T>> objDictEnumerator, List<Obj>? argCache, int remainingDepth, bool applyLimits, WafLibraryInvoker wafLibraryInvoker)
        {
            var mapNat = wafLibraryInvoker.ObjectMap();

            if (applyLimits && remainingDepth-- <= 0)
            {
                Log.Warning("EncodeDictionary: object graph too deep, truncating nesting {Items}", string.Join(", ", objDictEnumerator.Select(x => $"{x.Key}, {x.Value}")));
                return new Obj(mapNat);
            }

            var count = objDictEnumerator is IDictionary<string, object> objDict ? objDict.Count : objDictEnumerator.Count();

            if (applyLimits && count > WafConstants.MaxContainerSize)
            {
                Log.Warning<int, int>("EncodeDictionary: list too long, it will be truncated, count: {Count}, MaxMapOrArrayLength {MaxMapOrArrayLength}", count, WafConstants.MaxContainerSize);
                objDictEnumerator = objDictEnumerator.Take(WafConstants.MaxContainerSize);
            }

            foreach (var o in objDictEnumerator)
            {
                var name = o.Key;
                if (name != null)
                {
                    var value = EncodeInternal(o.Value, argCache, remainingDepth, applyLimits, wafLibraryInvoker);
                    wafLibraryInvoker.ObjectMapAdd(mapNat, name, Convert.ToUInt64(name.Length), value.RawPtr);
                }
                else
                {
                    Log.Warning("EncodeDictionary: ignoring dictionary member with null name");
                }
            }

            return new Obj(mapNat);
        }

        private static Obj CreateNativeString(string s, bool applyLimits, WafLibraryInvoker wafLibraryInvoker)
        {
            var encodeString =
                applyLimits
                    ? TruncateLongString(s)
                    : s;
            return new Obj(wafLibraryInvoker.ObjectStringLength(encodeString, Convert.ToUInt64(encodeString.Length)));
        }

        private static Obj CreateNativeBool(bool b, WafLibraryInvoker wafLibraryInvoker) => new(wafLibraryInvoker.ObjectBool(b));

        private static Obj CreateNativeLong(long value, WafLibraryInvoker wafLibraryInvoker) => new(wafLibraryInvoker.ObjectLong(value));

        private static Obj CreateNativeNull(WafLibraryInvoker wafLibraryInvoker) => new(wafLibraryInvoker.ObjectNull());

        private static Obj CreateNativeUlong(ulong value, WafLibraryInvoker wafLibraryInvoker) => new(wafLibraryInvoker.ObjectUlong(value));

        private static Obj CreateNativeDouble(double value, WafLibraryInvoker wafLibraryInvoker) => new(wafLibraryInvoker.ObjectDouble(value));

        public static string FormatArgs(object o)
        {
            // zero capacity because we don't know the size in advance
            var sb = StringBuilderCache.Acquire(0);
            FormatArgsInternal(o, sb);
            return StringBuilderCache.GetStringAndRelease(sb);
        }

        private static void FormatArgsInternal(object o, StringBuilder sb)
        {
            _ =
                o switch
                {
                    string s => sb.Append(s),
                    int i => sb.Append(i),
                    long i => sb.Append(i),
                    uint i => sb.Append(i),
                    ulong i => sb.Append(i),
                    double i => sb.Append(i),
                    IEnumerable<KeyValuePair<string, JToken>> objDict => FormatDictionary(objDict.Select(x => new KeyValuePair<string, object>(x.Key, x.Value)), sb),
                    IEnumerable<KeyValuePair<string, string>> objDict => FormatDictionary(objDict.Select(x => new KeyValuePair<string, object>(x.Key, x.Value)), sb),
                    IEnumerable<KeyValuePair<string, List<string>>> objDict => FormatDictionary(objDict.Select(x => new KeyValuePair<string, object>(x.Key, x.Value)), sb),
                    // dont remove IEnumerable<KeyValuePair<string, string[]>>, it is used for logging cookies which are this type in debug mode
                    IEnumerable<KeyValuePair<string, string[]>> objDict => FormatDictionary(objDict.Select(x => new KeyValuePair<string, object>(x.Key, x.Value)), sb),
                    IEnumerable<KeyValuePair<string, object>> objDict => FormatDictionary(objDict, sb),
                    IList<JToken> objs => FormatList(objs, sb),
                    IList<string> objs => FormatList(objs, sb),
                    // this becomes ugly but this should change once PR improving marshalling of the waf is merged
                    IList<long> objs => FormatList(objs, sb),
                    IList<ulong> objs => FormatList(objs, sb),
                    IList<int> objs => FormatList(objs, sb),
                    IList<uint> objs => FormatList(objs, sb),
                    IList<double> objs => FormatList(objs, sb),
                    IList<decimal> objs => FormatList(objs, sb),
                    IList<float> objs => FormatList(objs, sb),
                    IList<object> objs => FormatList(objs, sb),
                    _ => sb.Append($"Error: couldn't format type: {o?.GetType()}")
                };
        }

        private static StringBuilder FormatDictionary(IEnumerable<KeyValuePair<string, object>> objDict, StringBuilder sb)
        {
            sb.Append("{ ");
            using var enumerator = objDict.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                sb.Append(" }");
                return sb;
            }

            sb.Append(enumerator.Current.Key);
            sb.Append(": ");
            if (enumerator.Current.Value != null)
            {
                FormatArgsInternal(enumerator.Current.Value, sb);
            }

            while (enumerator.MoveNext())
            {
                sb.Append(", ");
                sb.Append(enumerator.Current.Key);
                sb.Append(": ");
                if (enumerator.Current.Value != null)
                {
                    FormatArgsInternal(enumerator.Current.Value, sb);
                }
            }

            sb.Append(" }");
            return sb;
        }

        private static StringBuilder FormatList<T>(IEnumerable<T> objs, StringBuilder sb)
        {
            sb.Append("[ ");
            using var enumerator = objs.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                sb.Append(" ]");
                return sb;
            }

            if (enumerator.Current != null)
            {
                FormatArgsInternal(enumerator.Current, sb);
            }

            while (enumerator.MoveNext())
            {
                if (enumerator.Current != null)
                {
                    FormatArgsInternal(enumerator.Current, sb);
                }
            }

            sb.Append(" ]");
            return sb;
        }
    }
}
