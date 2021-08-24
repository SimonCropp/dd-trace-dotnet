// <copyright file="IExecutionContext.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.ComponentModel;

namespace Datadog.Trace.ClrProfiler.AutoInstrumentation.AWS.SDK
{
    /// <summary>
    /// IExecutionContext interface for ducktyping
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IExecutionContext
    {
        /// <summary>
        /// Gets the RequestContext
        /// </summary>
        IRequestContext RequestContext { get; }

        /// <summary>
        /// Gets the ResponseContext
        /// </summary>
        IResponseContext ResponseContext { get; }
    }
}