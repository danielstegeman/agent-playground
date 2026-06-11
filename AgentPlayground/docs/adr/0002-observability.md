# 0002 — Observability

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

We must be able to see agent runs, tool calls, token counts, latencies, and errors — locally and when hosted.

## Considered Options

- **OpenTelemetry → console exporter** — zero setup, low signal.
- **OpenTelemetry → Aspire dashboard** — rich local UI for traces/metrics/logs.
- **OpenTelemetry → Azure Monitor / Application Insights** — default for Azure hosting.

## Decision Outcome

Chosen: **OpenTelemetry as the backbone; Aspire dashboard locally, Azure Monitor when hosted.**
OTel is wired once; the exporter is selected by environment, so no code change is needed to switch. The Aspire dashboard implies a small Aspire AppHost, which also smooths future local orchestration.

### Revisit when

We deploy → confirm Azure Monitor exporter and connection string are wired via configuration/Key Vault.
