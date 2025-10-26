# Cloud Suite - CRM SaaS Platform

## Introduction
Cloud Suite is a comprehensive **Customer Relationship Management (CRM) Software-as-a-Service (SaaS)** solution designed to help businesses streamline their customer interactions, sales pipelines, and marketing operations. Built on modern .NET 8 architecture with Elasticsearch integration, our platform offers:

- **360° Customer View**: Unified customer profiles with interaction history
- **Sales Automation**: Lead tracking and deal management
- **Marketing Tools**: Campaign management and analytics
- **Customizable Modules**: Adaptable to various business needs
- **Scalable Infrastructure**: Cloud-ready with microservices architecture

### Prerequisites
- .NET 8 SDK
- Docker (for containerized services)
- Elasticsearch 8.x
- PostgreSQL 15+

# API Endpoints


![image](https://github.com/user-attachments/assets/71e2eddd-6cfb-4ecb-a97c-107afcac7740)

![image](https://github.com/user-attachments/assets/69e4cff0-491f-4b98-88f2-d3e3a67892a1)

![image](https://github.com/user-attachments/assets/0f13ad71-2be8-4975-8d58-bfb93c1fb0ec)


## Migrations

on CloudSuite.Infrastructure project execute:

      dotnet ef migrations add InitialPostgres --project . --startup-project ..\Rest\CloudSuite.Services.Core.API --output-dir Context/Migrations
     dotnet ef database update --project . --startup-project ..\Rest\CloudSuite.Services.Core.API






