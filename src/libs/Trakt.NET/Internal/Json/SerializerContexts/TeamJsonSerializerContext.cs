#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktTeamMember))]
    [JsonSerializable(typeof(IReadOnlyList<TraktTeamMember>))]
    public sealed partial class TeamJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
