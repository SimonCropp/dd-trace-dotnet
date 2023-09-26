// <copyright file="AgentConnectivityCheckTests.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>
#nullable enable

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Datadog.Trace.TestHelpers;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

using static Datadog.Trace.Tools.dd_dotnet.Checks.Resources;

namespace Datadog.Trace.Tools.dd_dotnet.ArtifactTests.Checks
{
    public class AgentConnectivityCheckTests : ConsoleTestHelper
    {
        public AgentConnectivityCheckTests(ITestOutputHelper output)
            : base(output)
        {
        }

        public static IEnumerable<object[]> TestData => new List<object[]>
        {
            new object[] { new[] { ("DD_TRACE_AGENT_URL", "http://fakeurl:7777/") } },
            new object[] { new[] { ("DD_AGENT_HOST", "fakeurl"), ("DD_TRACE_AGENT_PORT", "7777") } },
            new object[] { new[] { ("DD_AGENT_HOST", "wrong"), ("DD_TRACE_AGENT_PORT", "1111"), ("DD_TRACE_AGENT_URL", "http://fakeurl:7777/") } },
        };

        [SkippableTheory]
        [Trait("RunOnWindows", "True")]
        [MemberData(nameof(TestData))]
        public async Task DetectAgentUrl((string, string)[] environmentVariables)
        {
            SkipOn.Platform(SkipOn.PlatformValue.MacOs);
            using var helper = await StartConsole(enableProfiler: true, environmentVariables);

            var output = await RunTool($"check process {helper.Process.Id}");

            output.Should().Contain(DetectedAgentUrlFormat("http://fakeurl:7777/"));
        }

        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task DetectTransportHttp()
        {
            SkipOn.Platform(SkipOn.PlatformValue.MacOs);
            using var agent = MockTracerAgent.Create(Output, TcpPortProvider.GetOpenPort());

            var url = $"http://127.0.0.1:{agent.Port}/";

            using var helper = await StartConsole(enableProfiler: true, ("DD_TRACE_AGENT_URL", url));

            var output = await RunTool($"check process {helper.Process.Id}");

            output.Should().Contain(ConnectToEndpointFormat(url, "HTTP"));
        }

#if NETCOREAPP3_1_OR_GREATER
        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task NoVersionUds()
        {
            SkipOn.Platform(SkipOn.PlatformValue.MacOs);
            var tracesUdsPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            var url = $"unix://{tracesUdsPath}";

            using var agent = MockTracerAgent.Create(Output, new UnixDomainSocketConfig(tracesUdsPath, null));
            agent.Version = null;
            using var helper = await StartConsole(enableProfiler: true, ("DD_TRACE_AGENT_URL", url));

            var output = await RunTool($"check process {helper.Process.Id}");

            output.Should().Contain(AgentDetectionFailed);
        }
#endif

        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task NoAgent()
        {
            var output = await RunTool($"check agent http://fakeurl/");

            // Note for future maintainers: this assertion needs to be changed to something smarter
            // if the error message stops being at the end of the string
            output.Should().Contain(ErrorDetectingAgent("http://fakeurl/", string.Empty));
        }

        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task FaultyAgent()
        {
            using var agent = MockTracerAgent.Create(Output, TcpPortProvider.GetOpenPort());

            agent.RequestReceived += (_, e) => e.Value.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var output = await RunTool($"check agent http://localhost:{agent.Port}/");

            output.Should().Contain(WrongStatusCodeFormat((int)HttpStatusCode.InternalServerError));
        }

        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task DetectVersion()
        {
            const string expectedVersion = "7.66.55";

            using var agent = MockTracerAgent.Create(Output, TcpPortProvider.GetOpenPort());
            agent.Version = expectedVersion;

            var output = await RunTool($"check agent http://localhost:{agent.Port}/");

            output.Should().Contain(DetectedAgentVersionFormat(expectedVersion));
        }

#if NETCOREAPP3_1_OR_GREATER
        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task DetectVersionUds()
        {
            const string expectedVersion = "7.66.55";

            var tracesUdsPath = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

            using var agent = MockTracerAgent.Create(Output, new UnixDomainSocketConfig(tracesUdsPath, null));
            agent.Version = expectedVersion;

            var output = await RunTool($"check agent unix://{tracesUdsPath}");

            output.Should().Contain(DetectedAgentVersionFormat(expectedVersion));
        }
#endif

        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task DetectVersionNamedPipes()
        {
            SkipOn.Platform(SkipOn.PlatformValue.MacOs);
            SkipOn.Platform(SkipOn.PlatformValue.Linux);

            const string expectedVersion = "7.66.55";

            var tracesPipeName = $"trace-{Guid.NewGuid()}";
            var metricsPipeName = $"trace-{Guid.NewGuid()}";

            using var agent = MockTracerAgent.Create(Output, new WindowsPipesConfig(tracesPipeName, metricsPipeName));
            agent.Version = expectedVersion;

            var output = await RunTool($"check agent", ("DD_TRACE_PIPE_NAME", tracesPipeName));

            output.Should().Contain(DetectedAgentVersionFormat(expectedVersion));
        }

        [SkippableFact]
        [Trait("RunOnWindows", "True")]
        public async Task NoVersion()
        {
            using var agent = MockTracerAgent.Create(Output, TcpPortProvider.GetOpenPort());
            agent.Version = null;

            var output = await RunTool($"check agent http://localhost:{agent.Port}/");

            output.Should().Contain(AgentDetectionFailed);
        }
    }
}
