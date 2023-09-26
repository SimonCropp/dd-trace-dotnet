﻿// <auto-generated/>
#nullable enable

using System.Threading;

namespace Datadog.Trace.Telemetry;
internal partial class CiVisibilityMetricsTelemetryCollector
{
    public void RecordCountLogCreated(Datadog.Trace.Telemetry.Metrics.MetricTags.LogLevel tag, int increment = 1)
    {
    }

    public void RecordCountIntegrationsError(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.InstrumentationError tag2, int increment = 1)
    {
        var index = 4 + ((int)tag1 * 3) + (int)tag2;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountSpanCreated(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName tag, int increment = 1)
    {
    }

    public void RecordCountSpanFinished(int increment = 1)
    {
    }

    public void RecordCountSpanEnqueuedForSerialization(Datadog.Trace.Telemetry.Metrics.MetricTags.SpanEnqueueReason tag, int increment = 1)
    {
    }

    public void RecordCountSpanDropped(Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason tag, int increment = 1)
    {
    }

    public void RecordCountTraceSegmentCreated(Datadog.Trace.Telemetry.Metrics.MetricTags.TraceContinuation tag, int increment = 1)
    {
    }

    public void RecordCountTraceChunkEnqueued(Datadog.Trace.Telemetry.Metrics.MetricTags.TraceChunkEnqueueReason tag, int increment = 1)
    {
    }

    public void RecordCountTraceChunkDropped(Datadog.Trace.Telemetry.Metrics.MetricTags.DropReason tag, int increment = 1)
    {
    }

    public void RecordCountTraceChunkSent(int increment = 1)
    {
    }

    public void RecordCountTraceSegmentsClosed(int increment = 1)
    {
    }

    public void RecordCountTraceApiRequests(int increment = 1)
    {
    }

    public void RecordCountTraceApiResponses(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode tag, int increment = 1)
    {
    }

    public void RecordCountTraceApiErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError tag, int increment = 1)
    {
    }

    public void RecordCountTracePartialFlush(Datadog.Trace.Telemetry.Metrics.MetricTags.PartialFlushReason tag, int increment = 1)
    {
    }

    public void RecordCountContextHeaderStyleInjected(Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle tag, int increment = 1)
    {
    }

    public void RecordCountContextHeaderStyleExtracted(Datadog.Trace.Telemetry.Metrics.MetricTags.ContextHeaderStyle tag, int increment = 1)
    {
    }

    public void RecordCountStatsApiRequests(int increment = 1)
    {
    }

    public void RecordCountStatsApiResponses(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode tag, int increment = 1)
    {
    }

    public void RecordCountStatsApiErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError tag, int increment = 1)
    {
    }

    public void RecordCountTelemetryApiRequests(Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryEndpoint tag, int increment = 1)
    {
    }

    public void RecordCountTelemetryApiResponses(Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryEndpoint tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode tag2, int increment = 1)
    {
    }

    public void RecordCountTelemetryApiErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.TelemetryEndpoint tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError tag2, int increment = 1)
    {
    }

    public void RecordCountVersionConflictTracerCreated(int increment = 1)
    {
    }

    public void RecordCountDirectLogLogs(Datadog.Trace.Telemetry.Metrics.MetricTags.IntegrationName tag, int increment = 1)
    {
    }

    public void RecordCountDirectLogApiRequests(int increment = 1)
    {
    }

    public void RecordCountDirectLogApiResponses(Datadog.Trace.Telemetry.Metrics.MetricTags.StatusCode tag, int increment = 1)
    {
    }

    public void RecordCountDirectLogApiErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.ApiError tag, int increment = 1)
    {
    }

    public void RecordCountWafInit(int increment = 1)
    {
    }

    public void RecordCountWafUpdates(int increment = 1)
    {
    }

    public void RecordCountWafRequests(Datadog.Trace.Telemetry.Metrics.MetricTags.WafAnalysis tag, int increment = 1)
    {
    }

    public void RecordCountIastExecutedSources(Datadog.Trace.Telemetry.Metrics.MetricTags.IastInstrumentedSources tag, int increment = 1)
    {
    }

    public void RecordCountIastExecutedPropagations(int increment = 1)
    {
    }

    public void RecordCountIastExecutedSinks(Datadog.Trace.Telemetry.Metrics.MetricTags.IastInstrumentedSinks tag, int increment = 1)
    {
    }

    public void RecordCountIastRequestTainted(int increment = 1)
    {
    }

    public void RecordCountCIVisibilityEventCreated(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventTypeWithCodeOwnerAndSupportedCiAndBenchmark tag2, int increment = 1)
    {
        var index = 480 + ((int)tag1 * 8) + (int)tag2;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityEventFinished(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventTypeWithCodeOwnerAndSupportedCiAndBenchmark tag2, int increment = 1)
    {
        var index = 520 + ((int)tag1 * 8) + (int)tag2;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageStarted(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCoverageLibrary tag2, int increment = 1)
    {
        var index = 560 + ((int)tag1 * 2) + (int)tag2;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageFinished(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestFramework tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCoverageLibrary tag2, int increment = 1)
    {
        var index = 570 + ((int)tag1 * 2) + (int)tag2;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityManualApiEvent(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 580 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityEventsEnqueueForSerialization(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[584], increment);
    }

    public void RecordCountCIVisibilityEndpointPayloadRequests(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityEndpoints tag, int increment = 1)
    {
        var index = 585 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityEndpointPayloadRequestsErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityEndpoints tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag2, int increment = 1)
    {
        var index = 587 + ((int)tag1 * 5) + (int)tag2;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityGitCommand(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCommands tag, int increment = 1)
    {
        var index = 597 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityGitCommandErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityCommands tag1, Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityExitCodes tag2, int increment = 1)
    {
        var index = 606 + ((int)tag1 * 7) + (int)tag2;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSearchCommits(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[669], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSearchCommitsErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 670 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsObjectsPack(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[675], increment);
    }

    public void RecordCountCIVisibilityGitRequestsObjectsPackErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 676 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSettings(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[681], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSettingsErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 682 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityGitRequestsSettingsResponse(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityITRSettingsResponse tag, int increment = 1)
    {
        var index = 687 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsRequest(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[691], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsRequestErrors(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityErrorType tag, int increment = 1)
    {
        var index = 692 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsResponseTests(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[697], increment);
    }

    public void RecordCountCIVisibilityITRSkippableTestsResponseSuites(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[698], increment);
    }

    public void RecordCountCIVisibilityITRSkipped(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 699 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityITRUnskippable(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 703 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityITRForcedRun(Datadog.Trace.Telemetry.Metrics.MetricTags.CIVisibilityTestingEventType tag, int increment = 1)
    {
        var index = 707 + (int)tag;
        Interlocked.Add(ref _buffer.Counts[index], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageIsEmpty(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[711], increment);
    }

    public void RecordCountCIVisibilityCodeCoverageErrors(int increment = 1)
    {
        Interlocked.Add(ref _buffer.Counts[712], increment);
    }
}