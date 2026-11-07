using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>JSON converter for <see cref="TraktCollectedAt" />.</summary>
    public sealed class TraktCollectedAtJsonConverter : JsonConverter<TraktCollectedAt>
    {
        /// <inheritdoc />
        public override bool CanConvert(Type typeToConvert) => typeof(TraktCollectedAt) == typeToConvert;

        /// <inheritdoc />
        public override TraktCollectedAt Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Null)
                return default;

            string? value = reader.GetString();

            if (string.IsNullOrEmpty(value))
                return default;

            return value switch
            {
                TraktCollectedAt.ReleasedValue => TraktCollectedAt.Released,
                TraktCollectedAt.UnknownValue => TraktCollectedAt.Unknown,
                TraktCollectedAt.NowValue => TraktCollectedAt.Now,
                _ => reader.TryGetDateTime(out DateTime dateTime)
                    ? new TraktCollectedAt(dateTime)
                    : new TraktCollectedAt(DateTime.Parse(value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal))
            };
        }

        /// <inheritdoc />
        public override void Write(Utf8JsonWriter writer, TraktCollectedAt value, JsonSerializerOptions options)
        {
            if (value.IsReleased)
            {
                writer.WriteStringValue(TraktCollectedAt.ReleasedValue);
            }
            else if (value.IsUnknown)
            {
                writer.WriteStringValue(TraktCollectedAt.UnknownValue);
            }
            else if (value.IsNow)
            {
                writer.WriteStringValue(TraktCollectedAt.NowValue);
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

