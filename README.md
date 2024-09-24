# Repository Overview

This repository contains multiple projects that demonstrate various implementations using ASP.NET Core, React.js, GraphQL, In-Memory Cache, and Auth0 for authentication and authorization.

## Projects

### 1. APIEstudiantes
**Description:**  
This project implements authentication and authorization using Auth0, with role-based access control (RBAC) and scopes in ASP.NET Core.

**Features:**
- Auth0 integration for user authentication
- Role-based access with predefined scopes
- Secure API endpoints using ASP.NET Core

**Technologies:**
- ASP.NET Core
- Auth0

---

### 2. GraphQL (Orders API)
**Description:**  
A GraphQL API for managing orders, built using ASP.NET Core.

**Features:**
- GraphQL schema for querying and mutating order data
- Efficient data retrieval using ASP.NET Core

**Technologies:**
- ASP.NET Core
- GraphQL

---

### 3. SpotifyGraphQLBFF
**Description:**  
A full-stack project featuring a React.js frontend and a Backend For Frontend (BFF) built in ASP.NET Core. It includes authentication and authorization with Auth0 and Spotify, and a GraphQL API for interacting with Spotify data.

**Features:**
- React.js frontend for user interaction
- Backend in ASP.NET Core using GraphQL
- Authentication and authorization with Auth0 and Spotify APIs
- Integration with Spotify’s data using GraphQL

**Technologies:**
- React.js
- ASP.NET Core (BFF)
- Auth0
- Spotify API
- GraphQL
- In-Memory Cache

---

## Research on Web Integration

This folder (`Research`) contains various materials related to the integration of applications in web environments. The documents are written in **Spanish**.

- **Client Secrets:** Some examples in this research required client secrets for testing purposes. All sensitive information has been removed or replaced with placeholders.
- **Configuration Files:** Any configuration involving sensitive data (such as API keys or client secrets) should be filled using environment variables. Follow the setup instructions in each project folder for further details.

**Important:** Never upload real client secrets or credentials to public repositories. Use `.env` files or secure vaults for handling sensitive information in a production environment.

---

## Getting Started

Each project is located in its respective folder. Navigate to the desired project folder for setup instructions.

```bash
cd APIEstudiantes
# or
cd GraphQL
# or
cd SpotifyGraphQLBFF
# or
cd research
