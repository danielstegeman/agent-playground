using Azure.Monitor.OpenTelemetry.Exporter;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry.Logs;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace AgentPlayground;

public static class TelemetryRegistration
{
    public static IServiceCollection AddAgentTelemetry(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var appInsightsConn = configuration["ApplicationInsights:ConnectionString"]
            ?? Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
        var serviceName = configuration["OpenTelemetry:ServiceName"]
            ?? Environment.GetEnvironmentVariable("OTEL_SERVICE_NAME")
            ?? "agentplayground-agent";

        services.AddOpenTelemetry()
            .ConfigureResource(r => r.AddService(serviceName))
            .WithTracing(tracing =>
            {
                tracing
                    .AddHttpClientInstrumentation()
                    .AddSource("Microsoft.Extensions.AI")
                    .AddSource("Microsoft.Agents.AI");

                if (!string.IsNullOrWhiteSpace(appInsightsConn))
                    tracing.AddAzureMonitorTraceExporter(o => o.ConnectionString = appInsightsConn);
                else
                    tracing.AddOtlpExporter(); // honours OTEL_EXPORTER_OTLP_ENDPOINT (Aspire dashboard)
            })
            .WithLogging(logging =>
            {
                if (!string.IsNullOrWhiteSpace(appInsightsConn))
                    logging.AddAzureMonitorLogExporter(o => o.ConnectionString = appInsightsConn);
                else
                    logging.AddOtlpExporter();
            });

        return services;
    }
}
