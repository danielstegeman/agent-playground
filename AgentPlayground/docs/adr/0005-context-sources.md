# 0005 — Context sources

- Status: accepted
- Date: 2026-06-11
- Context: code-first hello-world chat agent (`AgentPlayground`)

## Context and Problem Statement

Where does grounding/context come from?

## Considered Options

- **None** — rely on the model's own knowledge.
- **Pre-fetched context in the prompt** — stable, small, deterministic.
- **Tool-fetched at runtime** — dynamic, conversation-dependent.
- **RAG (vector search)** — large corpus, semantic queries.
- **Structured retrieval (SQL/Graph/API)** — schema-backed source of truth.

## Decision Outcome

Chosen: **None — rely on the model.**
A hello-world chat agent needs no grounding.

### Revisit when

Answers must reflect private or fresh data → choose pre-fetched, tool-fetched, or RAG, and define staleness/caching.
