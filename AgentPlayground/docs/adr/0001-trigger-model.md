# 0001 — Trigger model

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

How does the outside world invoke the agent? The trigger model constrains hosting and scaling.

## Considered Options

- **Console chat loop** — fastest dev loop, zero hosting; dead-end for sharing.
- **HTTP streaming (SSE/WebSocket)** — natural target for a shared chat agent; needs session-state handling at scale.
- **Event-driven / webhook** — decoupled and scalable; no token streaming, wrong fit for interactive chat.

## Decision Outcome

Chosen: **Console chat loop now, structured so an HTTP/SSE host is a drop-in later.**
Agent logic lives in its own project; the chat surface is a thin adapter. Adding an HTTP/SSE host is additive, not a rewrite.

### Revisit when

We want to share the agent with other users → add an HTTP/SSE host project on top of the existing agent project.
