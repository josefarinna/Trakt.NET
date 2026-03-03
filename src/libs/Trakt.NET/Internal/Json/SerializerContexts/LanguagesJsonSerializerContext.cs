#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktLanguage))]
    [JsonSerializable(typeof(IReadOnlyList<TraktLanguage>))]
    public sealed partial class LanguagesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
