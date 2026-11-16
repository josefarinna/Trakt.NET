# Favorites Post

In this example we create a [`TraktSyncFavoritesPost`](xref:TraktNET.TraktSyncFavoritesPost) to add items to user favorites.

First, we create a new Trakt.NET client.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs#L12-L18)]

The following lines show how to create a favorites post and send it in a request.

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs#L22-L30)]

The complete code for this example:

[!code-csharp[](../../../codesnippets/examples/parameters/postbuilder/FavoritesPostBuilderExample.cs)]
