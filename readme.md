# TenderFlow AI: Enterprise RFP Analysis & Decision Support

> "Transforming 100-page PDF tenders into data-backed 'Go/No-Go' decisions in minutes."

## The Business Problem

Enterprise sales and engineering teams spend hundreds of hours manually auditing Request for Proposals (RFPs). Misinterpreting a single technical requirement can lead to million-dollar losses or failed deliveries.

**TenderFlow AI** solves this by bridging the gap between unstructured document data and structured corporate knowledge (SQL Server).

## ✨ Key Agentic Features

### 🧠 Semantic-to-Structured Pipeline

Unlike simple chatbots, TenderFlow implements a multi-stage **Agentic Pipeline** using the **Microsoft Agent Framework**:

- **Tender Parser**: Deconstructs complex PDFs into semantic segments using recursive character chunking.
- **Compliance Auditor (The Core)**: A specialized agent that uses **Tool Calling** to query internal SQL databases. It cross-references tender requirements with real-time employee availability and past project references.
- **Risk Mitigation Engine**: Identifies "Deal Breakers" (e.g., missing ISO certifications or overlapping delivery windows) before the first meeting starts.

## 🛠 Modern Tech Stack

- **Backend**: .NET 10 (Clean Architecture, Web API)
- **Frontend**: Angular 21 (Signals, Reactive UI)
- **AI Orchestration**: Microsoft Agent Framework + Microsoft.Extensions.AI
- **Vector Layer**: Qdrant (Hybrid Search: Vector Similarity + Metadata Filtering)
- **Data Layer**: SQL Server (EF Core) for structured business state

## 🏗 Architecture & Design Patterns

The project follows **Clean Architecture** principles to ensure that AI logic remains provider-agnostic.

- **Domain-Driven Design (DDD)**: Entities like `Tender`, `RfpRequirement`, and `ComplianceAudit` define the ubiquitous language of the system.
- **RAG (Retrieval-Augmented Generation)**: High-precision extraction from PDFs combined with internal SQL context to eliminate LLM hallucinations.
- **Explainable AI (XAI)**: Every decision made by the Decision Support Agent is backed by specific citations from the source PDF and internal records.

## Getting Started

### Prerequisites

- .NET 10 SDK
- Node.js (for Angular 21)
- Docker (for SQL Server & Qdrant local containers)

### Setup

1.  Clone the repository.
2.  Set up your environment variables (API Keys for Cerebras/Gemini).
3.  Run the infrastructure:
    ```bash
    docker-compose up -d
    ```
4.  Use the provided **Sample RFP PDF** in the `/test-data` folder to run your first audit.

## 📈 Roadmap

- [ ] **Phase 1**: Basic PDF-to-SQL extraction.
- [ ] **Phase 2**: Agentic feasibility check with Tool Calling.
- [ ] **Phase 3**: Automated "Draft Proposal" generation based on findings.
