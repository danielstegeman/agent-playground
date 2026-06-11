# 0004 — Tool surface

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

What can the agent do beyond generating text?

## Considered Options

- **No tools** — pure chat.
- **In-process tool** (C# method with `[Description]`) — default for capabilities the agent owns.
- **MCP server** — when a tool is shared across multiple agents or owned by another team.
- **HTTP tool** — when an existing API is the source of truth.

## Decision Outcome

Chosen: **One sample in-process tool to demonstrate the pattern.**
A trivial tool (e.g. current time / echo) establishes the registration and `[Description]` convention so adding real tools later is mechanical.

### Revisit when

A real capability is needed → decide in-process vs MCP vs HTTP per tool; record name, I/O shape, side-effects, idempotency, owner.
