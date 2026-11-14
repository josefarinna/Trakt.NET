#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktAward))]
    [JsonSerializable(typeof(IReadOnlyList<TraktAward>))]
    [JsonSerializable(typeof(TraktAwardCeremony))]
    [JsonSerializable(typeof(IReadOnlyList<TraktAwardCeremony>))]
    [JsonSerializable(typeof(TraktUpcomingCeremony))]
    [JsonSerializable(typeof(IReadOnlyList<TraktUpcomingCeremony>))]
    [JsonSerializable(typeof(TraktTitleAward))]
    [JsonSerializable(typeof(IReadOnlyList<TraktTitleAward>))]
    [JsonSerializable(typeof(TraktPersonAward))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonAward>))]
    public sealed partial class AwardsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
