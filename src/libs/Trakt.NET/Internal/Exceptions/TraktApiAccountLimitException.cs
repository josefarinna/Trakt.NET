namespace TraktNET
{
    public sealed partial class TraktApiAccountLimitException
    {
        internal TraktApiAccountLimitException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
            UpgradeURL = parameters.TraktHeaders.UpgradeURL ?? string.Empty;
            IsVIPUser = parameters.TraktHeaders.IsVIPUser ?? false;
            AccountLimit = parameters.TraktHeaders.AccountLimit ?? 0;
        }
    }
}
