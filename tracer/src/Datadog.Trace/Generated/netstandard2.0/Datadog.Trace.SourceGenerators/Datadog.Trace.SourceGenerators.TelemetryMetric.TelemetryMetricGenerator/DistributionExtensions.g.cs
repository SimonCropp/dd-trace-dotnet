﻿// <auto-generated/>
#nullable enable

namespace Datadog.Trace.Telemetry.Metrics;
internal static partial class DistributionExtensions
{
    /// <summary>
    /// The number of separate metrics in the <see cref="Datadog.Trace.Telemetry.Metrics.Distribution" /> metric.
    /// </summary>
    public const int Length = 14;

    /// <summary>
    /// Gets the metric name for the provided metric
    /// </summary>
    /// <param name="metric">The metric to get the name for</param>
    /// <returns>The datadog metric name</returns>
    public static string GetName(this Datadog.Trace.Telemetry.Metrics.Distribution metric)
        => metric switch
        {
            Datadog.Trace.Telemetry.Metrics.Distribution.InitTime => "init_time",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointPayloadBytes => "endpoint_payload.bytes",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointPayloadRequestsMs => "endpoint_payload.requests_ms",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointPayloadEventsCount => "endpoint_payload.events_count",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointEventsSerializationMs => "endpoint_payload.events_serialization_ms",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitCommandMs => "git.command_ms",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsSearchCommitsMs => "git_requests.search_commits_ms",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsObjectsPackMs => "git_requests.objects_pack_ms",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsObjectsPackBytes => "git_requests.objects_pack_bytes",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsObjectsPackFiles => "git_requests.objects_pack_files",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsSettingsMs => "git_requests.settings_ms",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityITRSkippableTestsRequestMs => "itr_skippable_tests.request_ms",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityITRSkippableTestsResponseBytes => "itr_skippable_tests.response_bytes",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityCodeCoverageFiles => "code_coverage.files",
            _ => null!,
        };

    /// <summary>
    /// Gets whether the metric is a "common" metric, used by all tracers
    /// </summary>
    /// <param name="metric">The metric to check</param>
    /// <returns>True if the metric is a "common" metric, used by all languages</returns>
    public static bool IsCommon(this Datadog.Trace.Telemetry.Metrics.Distribution metric)
        => metric switch
        {
            _ => true,
        };

    /// <summary>
    /// Gets the custom namespace for the provided metric
    /// </summary>
    /// <param name="metric">The metric to get the name for</param>
    /// <returns>The datadog metric name</returns>
    public static string? GetNamespace(this Datadog.Trace.Telemetry.Metrics.Distribution metric)
        => metric switch
        {
            Datadog.Trace.Telemetry.Metrics.Distribution.InitTime => "general",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointPayloadBytes => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointPayloadRequestsMs => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointPayloadEventsCount => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityEndpointEventsSerializationMs => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitCommandMs => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsSearchCommitsMs => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsObjectsPackMs => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsObjectsPackBytes => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsObjectsPackFiles => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityGitRequestsSettingsMs => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityITRSkippableTestsRequestMs => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityITRSkippableTestsResponseBytes => "civisibility",
            Datadog.Trace.Telemetry.Metrics.Distribution.CIVisibilityCodeCoverageFiles => "civisibility",
            _ => null,
        };
}