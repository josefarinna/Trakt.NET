namespace TraktNET
{
    public sealed partial class TraktApiVipValidationException
    {
        internal TraktApiVipValidationException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
            => UpgradeURL = parameters.TraktHeaders.UpgradeURL ?? string.Empty;
    }
}
