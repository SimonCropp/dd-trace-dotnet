// <copyright file="IastVerifyScrubberExtensions.cs" company="Datadog">
// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2017 Datadog, Inc.
// </copyright>

using System.Collections.Generic;
using System.Text.RegularExpressions;
using Datadog.Trace.TestHelpers;
using VerifyTests;

namespace Datadog.Trace.Security.IntegrationTests.IAST
{
    public static class IastVerifyScrubberExtensions
    {
        private static readonly (Regex RegexPattern, string Replacement) LocationMsgRegex = (new Regex(@"(\S)*""location"": {(\r|\n){1,2}(.*(\r|\n){1,2}){0,3}(\s)*},"), string.Empty);
        private static readonly (Regex RegexPattern, string Replacement) ClientIp = (new Regex(@"["" ""]*http.client_ip: .*,(\r|\n){1,2}"), string.Empty);
        private static readonly (Regex RegexPattern, string Replacement) NetworkClientIp = (new Regex(@"["" ""]*network.client.ip: .*,(\r|\n){1,2}"), string.Empty);
        private static readonly (Regex RegexPattern, string Replacement) HashRegex = (new Regex(@"(\S)*""hash"": (-){0,1}([0-9]){1,12},(\r|\n){1,2}      "), string.Empty);
        private static readonly (Regex RegexPattern, string Replacement) RequestTaintedRegex = (new Regex(@"_dd.iast.telemetry.request.tainted:(\s)*([1-9])(\d*).?(\d*),"), "_dd.iast.telemetry.request.tainted:,");
        private static readonly (Regex RegexPattern, string Replacement) TelemetryExecutedSinks = (new Regex(@"_dd\.iast\.telemetry\.executed\.sink\.weak_.+: .{3},"), string.Empty);

        public static VerifySettings AddIastScrubbing(this VerifySettings settings, bool scrubHash = true)
        {
            var scrubbers = new List<(Regex RegexPattern, string Replacement)>();
            if (scrubHash) { scrubbers.Add(HashRegex); }
            return AddIastScrubbing(settings, scrubbers);
        }

        public static VerifySettings AddIastScrubbing(this VerifySettings settings, IEnumerable<(Regex RegexPattern, string Replacement)> extraScrubbers)
        {
            settings.AddRegexScrubber(LocationMsgRegex);
            settings.AddRegexScrubber(ClientIp);
            settings.AddRegexScrubber(NetworkClientIp);
            settings.AddRegexScrubber(RequestTaintedRegex);
            settings.AddRegexScrubber(TelemetryExecutedSinks);

            if (extraScrubbers != null)
            {
                foreach (var scrubber in extraScrubbers)
                {
                    settings.AddRegexScrubber(scrubber.RegexPattern, scrubber.Replacement);
                }
            }

            settings.ScrubEmptyLines();
            return settings;
        }
    }
}
