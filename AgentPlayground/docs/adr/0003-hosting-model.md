# 0003 — Hosting model

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

Where does the agent run once it leaves the dev machine?

## Considered Options

- **Azure Container Apps** — autoscaling, HTTP ingress, scale-to-zero; default for streaming chat.
- **Azure App Service** — if the team already runs App Service and avoids containers.
- **Azure Functions** — true event-driven, short-lived runs only.

## Decision Outcome

Chosen: **Local process now; Azure Container Apps as the deploy target.**
Container Apps fits an HTTP/SSE chat agent and supports a user-assigned managed identity for keyless Azure OpenAI access.

### Revisit when

First deploy → author Container Apps Bicep with UAMI, ACR pull, Key Vault refs, and OTel env vars.
