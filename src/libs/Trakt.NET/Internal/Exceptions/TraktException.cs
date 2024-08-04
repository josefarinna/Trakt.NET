namespace TraktNET
{
    public partial class TraktException
    {
        internal TraktException(string message, Exception? innerException = null)
            : base(message, innerException)
        {
        }
    }
}
