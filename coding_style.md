# C# Coding Style Guidelines (Trakt.NET)

These guidelines define the coding conventions for the `Trakt.NET` codebase. In addition to this document, the project enforces formatting and analyzer rules automatically via [.editorconfig](file:///.editorconfig).

## 1. General Principles & Modern C# Features
- Target modern C# / .NET conventions with **Nullable Reference Types** enabled (`#nullable enable`).
- Use **Allman style** braces (open brace on a new line).
- Use **4 spaces** for indentation (no tabs).
- **`.editorconfig` as single source of truth**: Ensure your code conforms to the analyzer and formatting rules configured in [.editorconfig](file:///.editorconfig).

## 2. Naming Conventions
- **`PascalCase`**: Classes, structs, interfaces, enums, methods, properties, and events.
- **`_camelCase`**: Private and internal instance fields (e.g., `private int _count;`).
- **`s_camelCase`**: Static fields (e.g., `private static readonly DateTime s_startTime;`).
- **`UPPER_CASE`**: Constants (e.g., `private const string DEFAULT_USER_AGENT = "Trakt.NET";`).
- **Public API Prefixes**:
  - Public classes, structs, enums: Prefix with `Trakt` (e.g., `TraktClient`, `TraktGenre`).
  - Public interfaces: Prefix with `ITrakt` (e.g., `ITraktClient`).
  - Exceptions: Inherit from `TraktException` or use `Trakt...Exception`.
  - Async methods: Append the `Async` suffix (e.g., `GetMovieGenresAsync`).
- **Language Keywords**: Use C# keywords instead of BCL types (e.g., `int`, `string`, `bool` instead of `Int32`, `String`, `Boolean`).

## 3. Formatting & Code Structure
- **Root Namespace**: The primary root namespace is `TraktNET`.
- **`using` Directives**: Place `using` directives at the top of the file, outside of `namespace` declarations, sorted alphabetically. Remove unused `using` directives.
- **Expression-bodied Members**: Use expression-bodied members (`=>`) for short properties, methods, lambdas, and accessors.
- **Implicit Object Creation & `var`**: Use `var` or `new()` when the type is obvious from the right-hand side.
- **Pattern Matching & Collection Expressions**: Prefer pattern matching (`is`, `is not`, switch expressions) and C# collection expressions (`[...]`).
- **Visibility Modifiers**: Always explicitly declare member accessibility (`public`, `internal`, `private`, `protected`). Accessibility modifiers should be first (e.g., `public static async`, not `static public async`).
- **`readonly` & `static`**: Use `readonly` for fields that are not reassigned. Place `static` before `readonly` (e.g., `private static readonly`).

## 4. Documentation & Public APIs
- All public types, properties, and methods must include XML documentation comments (`/// <summary>`, `<param>`, `<returns>`, `<remarks>`).
- Annotate API methods with links to the official [Trakt.tv API Documentation](https://docs.trakt.tv) when applicable.

---

## Example File

`TraktGenresModule.cs`

```csharp
namespace TraktNET
{
    /// <summary>
    /// Provides access to data retrieving methods specific to genres.
    /// <para>This module contains all methods of the "Trakt API Documentation - Genres" section.</para>
    /// </summary>
    public sealed partial class TraktGenresModule
    {
        private static readonly DateTime s_initializedAt = DateTime.UtcNow;
        private readonly TraktContext _context;

        public TraktGenresModule(TraktContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// <summary>Gets a list of all movie genres.</summary>
        /// <param name="extendedInfo">
        /// Specifies if you want to get the subgenre.
        /// <para>See also <seealso cref="TraktExtendedInfo" />.</para>
        /// </param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.
        /// <para>If provided, the exception <see cref="OperationCanceledException" /> should be catched.</para>
        /// </param>
        /// <returns>
        /// A response of type <see cref="TraktListResponse{TResponseContentType}" /> containing the queried genres.
        /// <para>See also <seealso cref="TraktResponse{TResponseContentType}" /> and <seealso cref="TraktGenre" />.</para>
        /// </returns>
        /// <remarks>
        /// OAuth authorization is not required.
        /// <para><see href="https://docs.trakt.tv/reference/getgenreslist">
        /// Trakt API Documentation: Genres: List
        /// </see></para>
        /// </remarks>
        /// <exception cref="TraktApiException">Thrown if the request fails.</exception>
        public Task<TraktListResponse<TraktGenre>> GetMovieGenresAsync(TraktExtendedInfo? extendedInfo = null,
            CancellationToken cancellationToken = default)
            => GetMovieGenresImplAsync(extendedInfo, cancellationToken);
    }
}
```

