using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>JSON converter for <see cref="TraktWatchedAt" />.</summary>
    public sealed class TraktWatchedAtJsonConverter : JsonConverter<TraktWatchedAt>
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) => typeof(TraktWatchedAt) == typeToConvert;

        /// <inheritdoc />
        public override TraktWatchedAt Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default;

            string? value = reader.GetString();

            if (string.IsNullOrEmpty(value))
                return default;

            return value switch
            {
                TraktWatchedAt.ReleasedValue => TraktWatchedAt.Released,
                TraktWatchedAt.UnknownValue => TraktWatchedAt.Unknown,
                TraktWatchedAt.NowValue => TraktWatchedAt.Now,
                _ => reader.TryGetDateTime(out DateTime dateTime)
                    ? new TraktWatchedAt(dateTime)
                    : new TraktWatchedAt(DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal))
            };
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, TraktWatchedAt value, JsonSerializerOptions options)
        {
            if (value.IsReleased)
            {
                writer.WriteStringValue(TraktWatchedAt.ReleasedValue);
            }
            else if (value.IsUnknown)
            {
                writer.WriteStringValue(TraktWatchedAt.UnknownValue);
            }
            else if (value.IsNow)
            {
                writer.WriteStringValue(TraktWatchedAt.NowValue);
            }
            else if (value.DateTime.HasValue)
            {
                writer.WriteStringValue(value.DateTime.Value);
            }
            else
            {
                writer.WriteNullValue();
            }
        }
    }
}
