#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktSeason))]
    [JsonSerializable(typeof(TraktSeasonIds))]
    [JsonSerializable(typeof(TraktSeasonMinimal))]
    public sealed partial class SeasonsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
