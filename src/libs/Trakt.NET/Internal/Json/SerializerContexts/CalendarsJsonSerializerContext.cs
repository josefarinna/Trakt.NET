#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktCalendarShow))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCalendarShow>))]
    [JsonSerializable(typeof(TraktCalendarMovie))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCalendarMovie>))]
    public sealed partial class CalendarsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
