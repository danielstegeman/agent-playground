# AgentPlayground

A code-first hello-world chat agent built on **Microsoft Agent Framework** (`Microsoft.Agents.AI`) and **Azure OpenAI**, targeting .NET 10.

## Projects

| Project | Role |
|---|---|
| `src/AgentPlayground.Host` | Console chat loop (entry point). |
| `src/AgentPlayground` | Agent build-up, DI wiring, telemetry, embedded instructions. |
| `src/AgentPlayground.Tools.Clock` | Sample in-process tool (`GetCurrentUtcTime`). |
| `tests/AgentPlayground.Tests` | Unit tests. |

Architecture decisions live in [docs/adr/](docs/adr/README.md).

## Prerequisites

- .NET 10 SDK
- An Azure OpenAI resource with a chat deployment (e.g. `gpt-4o`)
- `az login` (the agent authenticates with `DefaultAzureCredential` — no API keys)
- Your identity needs the **Cognitive Services OpenAI User** role on the resource

## Configure

Set your endpoint and deployment. Either edit `src/AgentPlayground.Host/appsettings.json`, or use user-secrets (preferred, keeps it out of source):

```powershell
cd src/AgentPlayground.Host
dotnet user-secrets set "AzureOpenAI:Endpoint" "https://<your-aoai-resource>.openai.azure.com/"
dotnet user-secrets set "AzureOpenAI:DeploymentName" "gpt-4o"
```

## Run

```powershell
az login
dotnet run --project src/AgentPlayground.Host
```

Then chat. Try `what time is it in UTC?` to exercise the sample tool. Type `exit` to quit.

## Telemetry

OpenTelemetry is wired in `TelemetryRegistration`. Locally it exports OTLP — point it at an Aspire dashboard:

```powershell
$env:OTEL_EXPORTER_OTLP_ENDPOINT = "http://localhost:18889"
```

When `APPLICATIONINSIGHTS_CONNECTION_STRING` (or `ApplicationInsights:ConnectionString`) is set, it exports to Azure Monitor instead.

## Build & test

```powershell
dotnet build
dotnet test
```
