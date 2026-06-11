# 0008 — Identity & secrets

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

How does the agent authenticate to Azure OpenAI, and where do secrets/config live?

## Considered Options

- **DefaultAzureCredential** — uses `az login` locally, managed identity in Azure; no keys on disk.
- **API key** — simplest, but a secret to store and rotate.

## Decision Outcome

Chosen: **`DefaultAzureCredential` locally (keyless), managed-identity-ready for Azure.**
Endpoint and deployment name come from environment variables / user-secrets locally. No API keys are stored.

### Revisit when

First deploy → assign a user-assigned managed identity the `Cognitive Services OpenAI User` role and move config to Key Vault references.
