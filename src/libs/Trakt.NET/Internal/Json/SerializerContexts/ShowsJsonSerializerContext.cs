#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktShow))]
    [JsonSerializable(typeof(TraktShowAirs))]
    [JsonSerializable(typeof(TraktShowIDs))]
    [JsonSerializable(typeof(TraktShowMinimal))]
    public sealed partial class ShowsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
