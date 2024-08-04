namespace TraktNET
{
    public sealed partial class TraktApiRateLimitException
    {
        internal TraktApiRateLimitException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
            RateLimitInfo = parameters.RateLimitInfo;
            RetryAfter = parameters.TraktHeaders.RetryAfter ?? 0;
        }
    }
}
