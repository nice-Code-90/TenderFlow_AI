# TenderFlow AI: Multi-Tenant Enterprise RFP Analysis & Decision Support

> "Transforming 100-page PDF tenders into data-backed 'Go/No-Go' decisions in minutes, tailored to any industry via Agentic Intelligence."

## The Business Problem

Enterprise sales and engineering teams spend hundreds of hours manually auditing Request for Proposals (RFPs). Misinterpreting a single technical requirement or missing a mandatory certification can lead to million-dollar losses or failed deliveries.

TenderFlow AI bridges the gap between unstructured document data and dynamic corporate knowledge using a multi-tenant, SaaS-first architecture.

## Key Agentic & SaaS Features

### Organization Onboarding Wizard

Unlike static tools, TenderFlow starts with a System Context Injection wizard. Users define their specific industry (IT, Construction, Legal) and their core "MappingKeys" (e.g., specific certifications, tech stacks). This primes the AI Agents to understand the unique "language" of your business before the first PDF is uploaded.

### Semantic-to-Structured Pipeline

TenderFlow implements a sophisticated Agentic Pipeline using the Microsoft Agent Framework:

- **Context-Aware Parser**: Deconstructs complex PDFs into semantic segments using recursive character chunking, guided by your Organization Profile.
- **Compliance Auditor (The Core)**: A specialized agent that uses Tool Calling to query an Elastic SQL Schema (EAV-inspired). It cross-references tender requirements with real-time employee availability and past project attributes.
- **Elastic Requirement Extraction**: Automatically maps PDF findings to your predefined MappingKeys, allowing the system to support any industry without database migrations.

### Risk Mitigation & XAI

- **Hard-Fail Identification**: Instantly flags missing mandatory requirements (e.g., "Must have ISO 27001").
- **Explainable AI (XAI)**: Every decision is backed by a citation from the source PDF and a reference to the specific internal record used for validation.

## Modern Tech Stack

- **Backend**: .NET 10 (Clean Architecture, Domain-Driven Design)
- **Frontend**: Angular 21 (Signals, Reactive UI, Multi-tenant Dashboard)
- **AI Orchestration**: Microsoft Agent Framework + Microsoft.Extensions.AI
- **Vector Layer**: Qdrant (Hybrid Search: Vector Similarity + Metadata Filtering)
- **Data Layer**: SQL Server (EF Core) using a Dynamic Attribute-Value pattern for infinite scalability.

## Architecture & Design Patterns

The project follows Clean Architecture principles to ensure AI logic remains provider-agnostic and the business core remains pure.

- **Metadata-Driven Design**: Decouples LLM reasoning from the database structure via a robust MappingKey system.
- **Hybrid RAG**: Combines high-precision extraction from PDFs with internal SQL/Vector context to eliminate hallucinations.
- **Chain-of-Thought (CoT) Reasoning**: Agents follow a logical sequence (Identify -> Retrieve -> Compare -> Verify) to ensure 100% audit accuracy.

## Getting Started

### Prerequisites

- .NET 10 SDK
- Node.js (for Angular 21)
- Docker (for SQL Server & Qdrant local containers)

### Setup

1. Clone the repository.
2. Set up environment variables (API Keys for Cerebras/Gemini).
3. Run infrastructure: `docker-compose up -d`.
4. Launch the Wizard: Access the UI and follow the onboarding to define your company's MappingKeys.

## Architectural Evolution & Milestones

To ensure enterprise-grade stability and industry-agnostic scalability, TenderFlow AI is developed through a series of structured architectural milestones, prioritizing a robust data foundation before agentic integration.

- **Milestone 1: Multi-Tenant Foundation & Elastic Domain Model**
  Implementation of the core Clean Architecture layers and the EAV-inspired (Entity-Attribute-Value) domain model. This allows the system to store diverse organizational data and tender requirements using dynamic MappingKeys without database schema modifications.

- **Milestone 2: Contextual Onboarding & Metadata Management**
  Development of the Organization Wizard for system context injection. This phase focuses on defining industry-specific metadata schemas and priming the AI environment with corporate-specific terminology and strategic priorities.

- **Milestone 3: Hybrid RAG & Document Intelligence**
  Integration of advanced PDF parsing engines and semantic chunking strategies. This milestone establishes the dual-stream data flow: indexing unstructured RFP text into Qdrant while maintaining relational links to the SQL Server business state.

- **Milestone 4: Agentic Orchestration & Compliance Auditing**
  Deployment of the Microsoft Agent Framework pipeline. This involves the implementation of specialized agents (Parser, Extractor, Auditor) that utilize Tool Calling to perform multi-source cross-referencing between tender demands and corporate capabilities.

- **Milestone 5: Strategic Decision Intelligence & XAI Dashboard**
  Finalization of the Go/No-Go decision engine and the Explainable AI (XAI) reporting layer. The focus is on providing human-readable justifications for AI decisions, integrated into a reactive Angular 21 dashboard powered by Signals.
