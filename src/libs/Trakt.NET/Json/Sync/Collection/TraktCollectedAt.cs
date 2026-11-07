using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// Represents when a collection item was collected: a specific UTC <see cref="System.DateTime" />,
    /// <see cref="Released" /> (<c>"released"</c>), <see cref="Unknown" /> (<c>"unknown"</c>), or <see cref="Now" /> (<c>"now"</c>).
    /// </summary>
    [JsonConverter(typeof(TraktCollectedAtJsonConverter))]
    public readonly record struct TraktCollectedAt
    {
        internal const string ReleasedValue = "released";
        internal const string UnknownValue = "unknown";
        internal const string NowValue = "now";

        private readonly string? _literal;

        /// <summary>Indicates that the item was collected on its release date (<c>"released"</c>).</summary>
        public static TraktCollectedAt Released => new(ReleasedValue);

        /// <summary>Indicates that the item was collected on an unknown date (<c>"unknown"</c>).</summary>
        public static TraktCollectedAt Unknown => new(UnknownValue);

        /// <summary>Indicates that the item was collected at the current time (<c>"now"</c>).</summary>
        public static TraktCollectedAt Now => new(NowValue);

        /// <summary>Gets the UTC <see cref="System.DateTime" /> if a specific timestamp was set; otherwise, <see langword="null" />.</summary>
        public DateTime? DateTime { get; }

        /// <summary>Gets a value indicating whether a specific <see cref="DateTime" /> value is set.</summary>
        public bool HasDateTime => DateTime.HasValue;

        /// <summary>Gets a value indicating whether this instance represents <see cref="Released" /> (<c>"released"</c>).</summary>
        public bool IsReleased => string.Equals(_literal, ReleasedValue, StringComparison.Ordinal);

        /// <summary>Gets a value indicating whether this instance represents <see cref="Unknown" /> (<c>"unknown"</c>).</summary>
        public bool IsUnknown => string.Equals(_literal, UnknownValue, StringComparison.Ordinal);

        /// <summary>Gets a value indicating whether this instance represents <see cref="Now" /> (<c>"now"</c>).</summary>
        public bool IsNow => string.Equals(_literal, NowValue, StringComparison.Ordinal);

        /// <summary>Gets the string representation of this value (<c>"released"</c>, <c>"unknown"</c>, <c>"now"</c>, or an ISO-8601 UTC timestamp).</summary>
        public string? Value => _literal ?? DateTime?.ToTraktLongDateTimeString();

        /// <summary>Initializes a new instance of the <see cref="TraktCollectedAt" /> struct with the specified <see cref="System.DateTime" />.</summary>
        /// <param name="dateTime">The datetime when the item was collected. Converted to UTC.</param>
        public TraktCollectedAt(DateTime dateTime)
        {
            DateTime = dateTime.ToUniversalTime();
            _literal = null;
        }

        private TraktCollectedAt(string literal)
        {
            DateTime = null;
            _literal = literal;
        }

        /// <summary>Returns the string representation of this <see cref="TraktCollectedAt" /> value.</summary>
        /// <returns>The string representation of this <see cref="TraktCollectedAt" /> value.</returns>
        public override string ToString() => Value ?? string.Empty;

        /// <summary>Implicitly converts a <see cref="System.DateTime" /> to a <see cref="TraktCollectedAt" />.</summary>
        /// <param name="dateTime">The datetime value.</param>
        public static implicit operator TraktCollectedAt(DateTime dateTime) => new(dateTime);

        /// <summary>Implicitly converts a <see cref="TraktCollectedAt" /> to a nullable <see cref="System.DateTime" />.</summary>
        /// <param name="collectedAt">The <see cref="TraktCollectedAt" /> value.</param>
        public static implicit operator DateTime?(TraktCollectedAt collectedAt) => collectedAt.DateTime;
    }
}

