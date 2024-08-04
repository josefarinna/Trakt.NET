namespace TraktNET
{
    public sealed partial class TraktApiCheckinException
    {
        internal TraktApiCheckinException(ExceptionParameters parameters, Exception? innerException = null)
            : base("Checkin is already in progress", parameters, innerException)
            => ExpiresAt = parameters.CheckinErrorResponse?.ExpiresAt;
    }
}
