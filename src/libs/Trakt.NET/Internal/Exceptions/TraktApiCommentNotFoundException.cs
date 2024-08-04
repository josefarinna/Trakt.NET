namespace TraktNET
{
    public sealed partial class TraktApiCommentNotFoundException
    {
        internal TraktApiCommentNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base("Comment Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
