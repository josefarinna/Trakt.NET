# Trakt.NET Project Guidelines for AI Agents

This file provides comprehensive context regarding the architecture, code structure, conventions, and workflows of the **Trakt.NET** repository. Refer to this document to understand the project without needing to re-explore it.

---

## 1. Project Overview

`Trakt.NET` is a modern .NET wrapper library (v2 architecture) for interacting with the **Trakt.tv API v2** (https://docs.trakt.tv).

### Key Architectural Features
- **Supported Runtimes**: .NET 6.0, 7.0, 8.0, 9.0, 10.0, and 11.0, as well as .NET Standard 2.0/2.1 and .NET Framework.
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
├── Changelogs/             # Frozen changelog of 1.x and older versions (CHANGELOG-v1.md)
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
├── CHANGELOG.md            # Changelog of 2.x versions (current)
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
   - **Acronyms & Abbreviations**: Write identifiers in uppercase (`ID`, `IDs`, `IMDB`, `TMDB`, `TVDB`, `MAL`), e.g. `TraktMovieIDs`, `ClientID`, `IMDBRatings`, `GetIDLookupResultsAsync`. `Url` and `Uri` keep the .NET casing (`ReturnUrl`, `RequestUri`). Spell out abbreviations that are not well known (`RottenTomatoesMeters`, not `RtMeters`). Parameters follow the same rule in camelCase (`movieIDs`, `showID`); some older parameters still use `Id`/`Ids` and must not be taken as reference.
   - **JSON Property Names**: The serializer uses the snake_case naming policy, which splits `IDs` into `i_ds` and joins `TMDBID` into `tmdbid`. When the property name does not convert to the Trakt API name (e.g. `ServerIDs` → `server_ids`, `RottenTomatoesMeters` → `rt_meters`), add `[JsonPropertyName("...")]` with the exact API name.
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

## 4. Trakt.tv API Reference (LLM Context & Discovery)

The official Trakt developer portal has migrated to `developer.trakt.tv`. Note that a centralized `llms.txt` file is no longer maintained on the root domain. Use the following sources for up-to-date API schema details:

- **Official Developer Portal**: https://developer.trakt.tv
- **Raw Markdown Context**: To pull clean documentation for context injection, append `.md` to any guide URL on the developer portal.
- **API Blueprints & OpenAPISpec**: Ground your knowledge of modules, endpoints, and structural parameters using the official [trakt/trakt-api](https://github.com) GitHub repository. 
  - Review the `/openapi` folder for strict JSON schemas.
  - Review the `/developer` folder for authentication and markdown guide sources.

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
3. **Documentation Publishing**:
   - The DocFX site is built on every CI run, but deployed to GitHub Pages (`gh-pages`) only from `v*` tags (`.github/workflows/documentation.yml`), so it always matches the released package. To redeploy it, run the CI workflow manually on the release tag.
4. **Release Process**:
   - Day-to-day work (features, fixes, Dependabot) targets `develop`, whose `src/version.json` holds the next version.
   - The version is not hard-coded anywhere else: the NuGet badge is dynamic, the install commands have no `--version`, the docs examples include the code instead of linking a tag, and `PackageReleaseNotes` is built from the computed version (`src/libs/Directory.Build.props`).
   - To close a version: set the release date in the `## [x.y.z]` section of `CHANGELOG.md`, add the `Postman/vx.y.z/` collection, run `nbgv prepare-release` from `src/` to create `release-x.y.z` and bump `develop` to the next minor version, then push the `vx.y.z` tag to publish NuGet and the documentation. Merge any fixes made in the release branch back into `develop`.
5. **Changelog**:
   - All 2.x changes go in `CHANGELOG.md` (root). `Changelogs/CHANGELOG-v1.md` holds 1.x and older versions and is frozen.
   - The version in progress is the top section, `## [x.y.z] - Unreleased`, with `###` subsections (`New Features & API Endpoints`, `Added & Updated Data Models`, `Breaking Changes`, `Removed / Deprecated`, `Improvements & Fixes`). Every user-visible change adds a short entry there.
   - When releasing, replace `Unreleased` with the release date (`YYYY-MM-DD`). `PackageReleaseNotes` points to `CHANGELOG.md` at the version tag.

---

## 6. Comprehensive Testing Guidelines & Mandatory Test Suites

Whenever creating or modifying functionality, **unit tests MUST be written or updated** across the corresponding test projects under `src/tests/libs/`:

### 1. API Modules Tests (`Trakt.NET.Modules.Tests/<ModuleName>/`)
Every API endpoint method must be tested following the same convention in all modules (see `MoviesModule/` for reference):
- **Main Theory with the Numeric ID**: The main test is `Test<Method>WithID` (or `Test<Method>` for endpoints without an identifier), a `[Theory]` that calls the `uint` ID overload. Its `[InlineData]` rows cover the request without optional parameters, **each optional parameter alone**, and **one row with all of them together**. Do not add rows or facts for intermediate combinations: the URI building of every combination is already tested in `Trakt.NET.Requests.Tests`.
- **Other Identifier Overloads**: The slug, IDs and object overloads get a single basic case each: `Test<Method>WithSlug`, `Test<Method>WithIDs` and `Test<Method>WithShow` / `WithList` / `WithMovie` / `WithPerson`.
- **Pagination & Navigation**: For paged endpoints (`TraktPagedResponse<T>`), `page` and `limit` are parameters of the main theory and the assertions use `response.Page.ShouldBe(page ?? 1U)` and `response.Limit.ShouldBe(limit ?? 10U)`, plus `PageCount` and `ItemCount`. Always write dedicated `Test<Method>WithIDPaging...` tests for `GetPreviousPageAsync()` and `GetNextPageAsync()`, asserting `HasPreviousPage` and `HasNextPage`.
- **Parameters that are not constants**: `[InlineData]` only accepts constants, so dates are passed as ISO strings and converted with `TestUtility.ParseUTCDateTime(...)`, arrays as `new uint[] { ... }`, and a filter either as simple parameters (e.g. `string? query`) that build the `TraktFilter` inside the test or, for a fixed complex filter, in a separate `Test<Method>WithFilter` theory.
- **OAuth Enforcement & Alias "me"**: Test OAuth requirements (`client.IgnoreOAuthIfOptional = false`) and URI template substitution when using the `"me"` shortcut (`users/me/...`).
- **Response Content**: Mock responses MUST be loaded from JSON fixture files in `src/tests/libs/JsonData/<ModuleName>/` with `TestUtility.GetJsonFileContentAsync(...)`; never build the response JSON inside the test.
- **Internal Request Validation vs. API Exception Handling**:
  - Request validation failures (null/empty/whitespace required parameters, invalid IDs) MUST be tested in `Test<Method>WithIDsThrowsArgumentException` (or `Test<Method>ThrowsArgumentException`).
  - The mapping of every HTTP error status code to its `TraktApiException` subclass is tested once in `RequestHandlerTests.TestThrowsApiException`. Each endpoint only tests, in `Test<Method>WithIDThrowsApiException` with `ModuleTestUtility.GetClient(uri, statusCode)`, the `404` (whose exception depends on the requested object type) and any status code with an endpoint-specific exception (e.g. OAuth errors in `AuthModule`, `409` in `CheckinModule`).
- **Naming**: Use `IDs` (not `Ids`), `ThrowsApiException` and `ThrowsArgumentException` in test names.

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
