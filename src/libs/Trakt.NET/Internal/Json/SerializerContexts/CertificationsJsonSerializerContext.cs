#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktCertification))]
    [JsonSerializable(typeof(IReadOnlyList<TraktCertification>))]
    [JsonSerializable(typeof(TraktCertifications))]
    public sealed partial class CertificationsJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif
