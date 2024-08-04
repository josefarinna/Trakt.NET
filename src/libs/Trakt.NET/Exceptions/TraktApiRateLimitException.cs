namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there are too many requests during a specific time period.</summary>
    public sealed partial class TraktApiRateLimitException : TraktApiException
    {
        /// <summary>Additional information parameters about the rate limit.</summary>
        public TraktRateLimitInfo? RateLimitInfo { get; }

        /// <summary>Amount of time in seconds after which a retry is possible.</summary>
        public uint RetryAfter { get; }
    }
}
