# Trakt.NET Project Guidelines for AI Agents

This file provides comprehensive context regarding the architecture, code structure, conventions, and workflows of the **Trakt.NET** repository. Refer to this document to understand the project without needing to re-explore it.

---

## 1. Project Overview

`Trakt.NET` is a modern .NET wrapper library (v2 architecture) for interacting with the **Trakt.tv API v2** (https://docs.trakt.tv).

### Key Architectural Features
- **Supported Runtimes**: .NET 6.0, 7.0, 8.0, 9.0, and 10.0, as well as .NET Standard 2.0/2.1 and .NET Framework.
- **Concrete Data Models (`record class`)**: Replaced all legacy `ITrakt...` interfaces with concrete `record class` types for zero allocation overhead and maximum performance.
- **`System.Text.Json` Serialization**: Utilizes **Source Generation** (`System.Text.Json.Serialization`) without reflection for high performance and full compatibility with **Native AOT** (`IsAotCompatible`) and **Trimming** (`IsTrimmable`).
- **Media Image Support**: Full support for retrieving metadata and images (`TraktExtendedInfo.Images`).
- **Automatic Versioning**: Managed via `Nerdbank.GitVersioning` through `src/version.json`.

---

## 2. Directory and Project Structure

```
Trakt.NET/
├── .github/
│   └── workflows/          # GitHub Actions workflows (ci.yml, build.yml)
├── Changelogs/             # Release notes per version (v2.0.0-alpha.2.md, etc.)
├── docs/                   # Website and technical documentation (DocFX / Markdown)
├── src/
│   ├── libs/
│   │   ├── Directory.Build.props  # Shared NuGet package properties
│   │   ├── Trakt.NET/             # Main library project (Namespace: TraktNET)
│   │   │   ├── Enums/             # Strongly-typed enumerations
│   │   │   ├── Exceptions/        # Exception hierarchy (TraktException)
│   │   │   ├── Internal/          # Private implementations and internal helpers
│   │   │   ├── Json/              # System.Text.Json Source Generation contexts
│   │   │   ├── Modules/           # API modules (Movies, Shows, Sync, Auth, etc.)
│   │   │   ├── Parameters/        # Filter options and request builders
│   │   │   ├── Responses/         # Response wrappers (TraktResponse, TraktListResponse)
│   │   │   └── TraktClient.cs     # Main client entry point
│   │   └── Trakt.NET.HttpClientFactory/ # Extension for IHttpClientFactory & IoC
│   ├── tests/              # Unit and integration test projects
│   ├── version.json        # Version configuration (Nerdbank.GitVersioning)
│   └── Trakt.NET.slnx      # Main .NET solution
├── .editorconfig           # C# formatting rules and code analyzers
├── AGENTS.md               # AI agent guidelines
└── coding_style.md         # C# coding style guide
```

---

## 3. Code & Development Conventions

1. **Primary Root Namespace**: Always use `TraktNET` for public types in the library project.
2. **Formatting & Indentation**:
   - Strictly follow the rules defined in [.editorconfig](file:///.editorconfig).
   - **Allman** brace style (opening brace on a new line).
   - **4 spaces** indentation (no tabs).
3. **Naming & Prefixes**:
   - Classes / Models / Enums: `PascalCase`, prefixed with `Trakt` (e.g., `TraktShow`, `TraktGenre`).
   - **Concrete Record Models (No Data Interfaces)**: In v2 architecture, all legacy data model interfaces (`ITraktMovie`, `ITraktShow`, etc.) were eliminated in favor of concrete `record class` types for zero allocation overhead. Public interfaces are reserved strictly for rare internal/header abstractions (prefixed with `ITrakt`, e.g., `ITraktIDs`, `ITraktResponseHeaders`).
   - Private Fields: `_camelCase` for instance fields, `s_camelCase` for static fields.
   - Constants: `UPPER_CASE`.
   - Async Methods: Always include the `Async` suffix and accept `CancellationToken cancellationToken = default`.
4. **Modern C#**:
   - Always enable `#nullable enable`.
   - Use expression-bodied members (`=>`) for concise properties and methods.
   - Prefer pattern matching (`is`, `is not`, switch expressions) and collection expressions (`[...]`).
5. **XML Documentation**:
   - Every public API element must include XML documentation (`/// <summary>`, `<param>`, `<returns>`, `<remarks>`).
   - Link API endpoints to the official Trakt documentation in `<remarks>`.
6. **System.Text.Json Source Generation & Native AOT Registration**:
   - **Mandatory Model Registration**: Every new or modified data model class, DTO, or response object (`Trakt...`) MUST be registered in the corresponding `JsonSerializerContext` under `src/libs/Trakt.NET/Internal/Json/SerializerContexts/`.
   - **Single & Collection Payload Types**: Always decorate the context class with `[JsonSerializable(typeof(TModel))]` and `[JsonSerializable(typeof(IReadOnlyList<TModel>))]` (or list variants).
   - **Zero-Reflection**: Never rely on reflection-based JSON serialization; all JSON operations must compile cleanly with source generators for Native AOT (`IsAotCompatible`) and assembly trimming (`IsTrimmable`).
---

## 4. Trakt.tv API Reference (Official LLM Docs)

For any development involving Trakt.tv API calls, consult the official LLM-optimized references:
- **Main Index**: https://docs.trakt.tv/llms.txt
- **Official Guides**: https://docs.trakt.tv/docs/llms.txt
- **Endpoint Reference**: https://docs.trakt.tv/reference/llms.txt

---

## 5. CI/CD, Testing & NuGet Publishing

1. **Local Verification Commands**:
   ```pwsh
   dotnet restore src/
   dotnet build src/ --configuration Release --no-restore
   dotnet test src/ --configuration Release --no-build --no-restore
   ```
2. **NuGet Publishing (OIDC Trusted Publishing)**:
   - Triggered automatically in GitHub Actions on pushing a Git tag (`v*`, e.g., `v2.0.0-alpha.2`).
   - **NuGet.org Account**: `jose.farinna`
   - **Deployment Workflow**: `.github/workflows/ci.yml` -> `build.yml`
   - Requires `id-token: write` permission in CI jobs to generate ephemeral OIDC tokens.

---

## 6. Comprehensive Testing Guidelines & Mandatory Test Suites

Whenever creating or modifying functionality, **unit tests MUST be written or updated** across the corresponding test projects under `src/tests/libs/`:

### 1. API Modules Tests (`Trakt.NET.Modules.Tests/<ModuleName>/`)
Every API endpoint method must include comprehensive test cases covering all input permutations:
- **Default Request**: Test execution without optional parameters.
- **Extended Info**: Test with `TraktExtendedInfo` options (`Full`, `Images`, etc.).
- **Pagination Parameters & Navigation**: For paged endpoints (`TraktPagedResponse<T>`), explicitly test `Page`, `Limit`, and `Page` + `Limit` parameter combinations, asserting `Page`, `Limit`, `PageCount`, and `ItemCount` response headers. Crucially, **always write dedicated tests for `GetPreviousPageAsync()` and `GetNextPageAsync()` navigation methods**, asserting `HasPreviousPage` and `HasNextPage` flags.
- **Filters & Options**: Test filter objects (`TraktShowFilter`, `TraktMovieFilter`, etc.) and query options when supported.
- **Parameter Combinations**: Test combined permutations (Extended Info + Pagination + Filters).
- **OAuth Enforcement & Alias "me"**: Test OAuth requirements (`client.IgnoreOAuthIfOptional = false`) and URI template substitution when using the `"me"` shortcut (`users/me/...`).
- **Internal Request Validation vs. API Exception Handling**:
  - Request validation failures (null/empty/whitespace required parameters, invalid IDs) MUST be tested for throwing `TraktRequestValidationException`.
  - HTTP error status codes (`400`, `401`, `403`, `404`, `420`, `422`, `423`, `429`, `500`, `502`, `503`, `504`, `520`, `521`, `522`) MUST be tested using `ModuleTestUtility.GetClient(uri, statusCode)` with `[Theory]` to verify that the appropriate `TraktApiException` subclass is thrown.

### 2. JSON Serialization Tests (`Trakt.NET.Json.Tests/`)
Every new or modified data model class or DTO must include JSON unit tests:
- **Mock JSON Fixture Mandate**: Deserialization reader unit tests (`SingleObjectReader`, `ArrayReader`) MUST load mock JSON fixture files (`.json`) from `src/tests/libs/JsonData/<ModuleName>/` using `TestUtility.GetJsonFileContentAsync(...)`.
- **Field-by-Field Assertions**: Never stop at asserting non-null; perform deep field-by-field assertions (`ShouldBe`) on every deserialized model property to verify exact property mappings.
- **Writer/Serialization Tests**: Verify serializing model instances back to JSON.
- **Source Generation Context Verification**: Ensure `System.Text.Json` Source Generation context handles both single models (`[JsonSerializable(typeof(TModel))]`) and `IReadOnlyList<TModel>` collections cleanly without reflection.

### 3. Enum Tests (`Trakt.NET.Core.Tests/Enums/`)
Every new or modified enumeration (`Trakt...Enum`) must include enum tests:
- **String Conversion & Display Names**: Verify conversion between enum values and API string values (`ToURI()`, `DisplayName()`).
- **Default & Null Handling**: Verify default enum values and invalid/unknown string parsing.

### 4. Request Builder Tests (`Trakt.NET.Requests.Tests/`)
Every new or modified request object must include request tests:
- **URI & Parameter Formatting**: Verify generated request URIs match expected API paths and query parameters.
- **Authorization & Headers**: Verify OAuth/Client-ID header requirements and HTTP method selection (`GET`, `POST`, `PUT`, `DELETE`).

### Assertion Standards
- Assert non-null responses and contents (`response.ShouldNotBeNull()`, `response.IsSuccess.ShouldBeTrue()`, `response.Content.ShouldNotBeNull()`).
- Verify list item counts and specific object properties parsed from JSON test fixtures.
