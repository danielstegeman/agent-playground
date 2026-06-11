# 0007 — Guardrails

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

What must never happen? (PII handling, prompt injection, content filtering, tool-call allow/deny, audit retention.)

## Considered Options

- **None** — acceptable only for trusted local input.
- **Basic guardrail middleware stub** — placeholder pipeline to fill in later.
- **Full guardrails** — input/output/tool-call checks via `IChatClient` middleware + `AIFunction` wrappers.

## Decision Outcome

Chosen: **None now — mandatory before untrusted input.**
The hello-world runs locally with trusted input from the developer only.

### Revisit when

**Before** the agent accepts any untrusted/end-user input → add input, output, and tool-call guardrails (PII redaction, prompt-injection detection, content filtering, audit logging). This is a hard gate, not optional.
