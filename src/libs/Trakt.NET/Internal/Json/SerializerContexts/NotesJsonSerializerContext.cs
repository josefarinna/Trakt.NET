#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktNote))]
    [JsonSerializable(typeof(TraktNoteAttachedTo))]
    [JsonSerializable(typeof(TraktNoteItem))]
    [JsonSerializable(typeof(TraktNotePost))]
    public sealed partial class NotesJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
