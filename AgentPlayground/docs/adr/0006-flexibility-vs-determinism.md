# 0006 — Flexibility vs determinism

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

How much of the agent's behaviour is free-form LLM reasoning vs a deterministic, auditable skeleton?

## Considered Options

- **Single free-form agent loop** — maximum flexibility, minimum predictability.
- **Agent-as-tool / handoff** — more structure, still LLM-driven.
- **Workflow orchestrator (CQRS/DAG/state machine)** — deterministic skeleton with LLM steps inside.

## Decision Outcome

Chosen: **Single free-form chat loop.**
Right fit for hello-world. The project layout keeps the door open to introduce an orchestrator without restructuring the agent.

### Revisit when

Some steps must run the same way every time / need auditability → wrap those in a workflow orchestrator with agent steps inside.
