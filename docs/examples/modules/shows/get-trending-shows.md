# Get Trending Shows

In this example we get trending shows.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsExample.cs#L13-L15)]

The following lines show how to get trending shows.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsExample.cs#L19-L24)]

For getting a specific page, pass `page` and `limit` arguments.

[!code-csharp[](../../../codesnippets/examples/modules/shows/TrendingShowsPagedExample.cs#L19-L28)]

Here are the complete codes.

Trending Shows default page:
[Trakt.NET/docs/codesnippets/examples/modules/shows/TrendingShowsExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0/docs/codesnippets/examples/modules/shows/TrendingShowsExample.cs)

Trending Shows paged:
[Trakt.NET/docs/codesnippets/examples/modules/shows/TrendingShowsPagedExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0/docs/codesnippets/examples/modules/shows/TrendingShowsPagedExample.cs)
