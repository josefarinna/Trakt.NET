namespace TraktNET
{
    public sealed partial class TraktApiVIPValidationException
    {
        internal TraktApiVIPValidationException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
            => UpgradeURL = parameters.TraktHeaders.UpgradeURL ?? string.Empty;
    }
}
