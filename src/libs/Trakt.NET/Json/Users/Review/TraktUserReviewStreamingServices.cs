namespace TraktNET
{
    /// <summary>Represents subscription streaming services breakdown in a month in review.</summary>
    public record class TraktUserReviewStreamingServices
    {
        /// <summary>Gets or sets the 2-character country code.</summary>
        public string? Country { get; set; }

        /// <summary>
        /// Gets or sets the list of streaming services.
        /// <para>See also <seealso cref="TraktUserReviewStreamingService" />.</para>
        /// </summary>
        public IReadOnlyList<TraktUserReviewStreamingService>? Services { get; set; }
    }
}
