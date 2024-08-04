namespace TraktNET
{
    public sealed partial class TraktApiLockedUserAccountException
    {
        internal TraktApiLockedUserAccountException(ExceptionParameters parameters, Exception? innerException = null)
            : base(parameters, innerException)
        {
        }
    }
}
