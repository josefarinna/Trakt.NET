using System.Text.Json;

#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;
#endif

namespace TraktNET
{
    internal static class StreamExtensions
    {
        internal static async Task<TJsonObjectType?> ReadAsJsonAsync<TJsonObjectType>(this Stream stream,
            CancellationToken cancellationToken = default) where TJsonObjectType : class
        {
            TJsonObjectType? jsonObjectType;

#if NET6_0_OR_GREATER
            JsonSerializerContext jsonSerializerContext = JsonSerializerContextFactory.GetContext<TJsonObjectType>();

            jsonObjectType = await JsonSerializer.DeserializeAsync(stream, typeof(TJsonObjectType),
                jsonSerializerContext, cancellationToken).ConfigureAwait(false) as TJsonObjectType;
#else
            jsonObjectType = await JsonSerializer.DeserializeAsync<TJsonObjectType>(stream,
                Constants.Json.JsonOptions, cancellationToken).ConfigureAwait(false);
#endif

            return jsonObjectType;
        }
    }
}
