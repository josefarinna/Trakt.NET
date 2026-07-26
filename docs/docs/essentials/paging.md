# Paging

[`TraktPagedResponse<TContentType>`](xref:TraktNET.TraktPagedResponse`1) objects have a builtin feature for navigating through pages.

A paged response has properties returning pagination status:

- `HasPreviousPage`: Returns whether you can navigate to a previous page.
- `HasNextPage`: Returns whether you can navigate to a next page.

For navigating through pages, a paged response provides methods:

- `GetPreviousPageAsync()`: Navigate to a previous page if available.
- `GetNextPageAsync()`: Navigate to a next page if available.

## Example
### Get all trending shows
```csharp
using TraktNET;

var client = new TraktClient("client-id", "");

try
{
    // Get the first page with 40 items
    TraktPagedResponse<TraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(page: 1, limit: 40);

    // Load all pages of trending shows
    while (trendingShowsResponse.HasNextPage)
    {
        trendingShowsResponse = await trendingShowsResponse.GetNextPageAsync();
    }
}
catch (TraktException ex)
{
    // ...
}
```

### Get pages backwards
```csharp
using TraktNET;

var client = new TraktClient("client-id", "");

try
{
    // Get the 10th page with 40 items
    TraktPagedResponse<TraktTrendingShow> trendingShowsResponse = await client.Shows.GetTrendingShowsAsync(page: 10, limit: 40);

    // Load all previous pages
    while (trendingShowsResponse.HasPreviousPage)
    {
        trendingShowsResponse = await trendingShowsResponse.GetPreviousPageAsync();
    }
}
catch (TraktException ex)
{
    // ...
}
```
