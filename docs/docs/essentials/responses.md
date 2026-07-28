# Responses

**Trakt.NET** has a response system with four primary response types.

## Response Types

- [`TraktNoContentResponse`](xref:TraktNET.TraktNoContentResponse) for Trakt responses without content (HTTP Code 204 No Content)
- [`TraktResponse<TContentType>`](xref:TraktNET.TraktResponse`1) for Trakt responses that return a single object, where `TContentType` is the type of that object
- [`TraktListResponse<TContentType>`](xref:TraktNET.TraktListResponse`1) for Trakt responses that return a list of objects, where `TContentType` is the type of a list item object
- [`TraktPagedResponse<TContentType>`](xref:TraktNET.TraktPagedResponse`1) for Trakt responses that return a list with pagination headers, where `TContentType` is the type of a list item object

## Response Properties

- `bool IsSuccess`: Indicates whether the request succeeded.

[`TraktResponse<TContentType>`](xref:TraktNET.TraktResponse`1), [`TraktListResponse<TContentType>`](xref:TraktNET.TraktListResponse`1) and [`TraktPagedResponse<TContentType>`](xref:TraktNET.TraktPagedResponse`1) also have:

- `bool HasValue`: Indicates whether the response contains a value.
- `TContentType Value` / `IReadOnlyList<TContentType> Content`: The actual response data payload.

## Exceptions

By default, the library throws a [`TraktException`](xref:TraktNET.TraktException) (or subclass such as `TraktApiNotFoundException`, `TraktApiAuthorizationException`, etc.) when a request fails or returns an HTTP error status code. Wrap calls in a `try`-`catch` block to handle API errors.

## Response Headers

Every response type except [`TraktNoContentResponse`](xref:TraktNET.TraktNoContentResponse) exposes response metadata headers returned by the Trakt API:

- `TraktSortBy? SortBy`
- `TraktSortHow? SortHow`
- `DateTime? StartDate`
- `DateTime? EndDate`
- `uint? Page`
- `uint? Limit`
- `uint? ItemCount`
- `uint? PageCount`
- `string? RateLimit`
- `int? RetryAfter`

## Example Usage

```csharp
using TraktNET;

var client = new TraktClient("client-id");

try
{
    TraktExtendedInfo extendedInfo = TraktExtendedInfo.Full;
    TraktPagedResponse<TraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(extendedInfo: extendedInfo, page: 1, limit: 10);

    if (trendingShowsResponse.IsSuccess && trendingShowsResponse.HasValue)
    {
        Console.WriteLine($"Current Page: {trendingShowsResponse.Page}");
        Console.WriteLine($"Current Page Limit: {trendingShowsResponse.Limit}");
        Console.WriteLine($"Page Count: {trendingShowsResponse.PageCount}");
        Console.WriteLine($"Total Item Count: {trendingShowsResponse.ItemCount}");

        foreach (TraktTrendingShow trendingShow in trendingShowsResponse.Content)
        {
            Console.WriteLine($"Show: {trendingShow.Title} / Watchers: {trendingShow.Watchers}");
        }
    }

    // Built-in pagination for paged responses
    if (trendingShowsResponse.HasNextPage)
    {
        trendingShowsResponse = await trendingShowsResponse.GetNextPageAsync();

        // Get back to previous page
        trendingShowsResponse = await trendingShowsResponse.GetPreviousPageAsync();
    }
}
catch (TraktException ex)
{
    Console.WriteLine($"Trakt API Error: {ex.Message}");
}
```
