#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktList))]
    [JsonSerializable(typeof(IReadOnlyList<TraktList>))]
    [JsonSerializable(typeof(TraktListIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktListIDs>))]
    [JsonSerializable(typeof(TraktListImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktListImages>))]
    [JsonSerializable(typeof(TraktListItem))]
    [JsonSerializable(typeof(IReadOnlyList<TraktListItem>))]
    [JsonSerializable(typeof(TraktListItemsReorderPost))]
    [JsonSerializable(typeof(TraktListItemsReorderPostResponse))]
    [JsonSerializable(typeof(TraktListItemUpdatePost))]
    [JsonSerializable(typeof(TraktListLike))]
    [JsonSerializable(typeof(IReadOnlyList<TraktListLike>))]
    [JsonSerializable(typeof(TraktPopularList))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPopularList>))]
    [JsonSerializable(typeof(TraktTrendingList))]
    [JsonSerializable(typeof(IReadOnlyList<TraktTrendingList>))]
    public sealed partial class ListsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
