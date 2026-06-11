# Architecture Decision Records

MADR-style decision records for **AgentPlayground**, a code-first hello-world chat agent.

| # | Decision | Choice |
|---|---|---|
| [0001](0001-trigger-model.md) | Trigger model | Console now, structured for HTTP/SSE later |
| [0002](0002-observability.md) | Observability | OpenTelemetry; Aspire dashboard local, Azure Monitor hosted |
| [0003](0003-hosting-model.md) | Hosting model | Local now; Azure Container Apps target |
| [0004](0004-tool-surface.md) | Tool surface | One sample in-process tool |
| [0005](0005-context-sources.md) | Context sources | None — rely on the model |
| [0006](0006-flexibility-vs-determinism.md) | Flexibility vs determinism | Single free-form chat loop |
| [0007](0007-guardrails.md) | Guardrails | None now; mandatory before untrusted input |
| [0008](0008-identity-and-secrets.md) | Identity & secrets | DefaultAzureCredential, keyless |

Each record lists the chosen option, alternatives considered, rationale, and a "revisit when" trigger.
