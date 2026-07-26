# Get Show Details

In this example we get the details of a single show.

Since we do not need authentication or authorization for this example, only the Client-ID is required.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExample.cs#L13-L15)]

Set the Trakt-ID or -Slug for the show.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExample.cs#L18-L20)]

The following lines show how to get minimal information about a show.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExample.cs#L24-L40)]

The following lines show how to get full information about a show using `TraktExtendedInfo.Full | TraktExtendedInfo.Images`.

[!code-csharp[](../../../codesnippets/examples/modules/shows/SingleShowExtendedExample.cs#L24-L89)]

Here are the complete codes.

Single Show without extended info:
[Trakt.NET/docs/codesnippets/examples/modules/shows/SingleShowExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0-alpha.1/docs/codesnippets/examples/modules/shows/SingleShowExample.cs)

Single Show with extended info:
[Trakt.NET/docs/codesnippets/examples/modules/shows/SingleShowExtendedExample.cs](https://github.com/josefarinna/Trakt.NET/tree/v2.0.0-alpha.1/docs/codesnippets/examples/modules/shows/SingleShowExtendedExample.cs)
