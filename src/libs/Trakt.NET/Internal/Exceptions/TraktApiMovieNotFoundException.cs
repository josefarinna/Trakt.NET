namespace TraktNET
{
    public sealed partial class TraktApiMovieNotFoundException
    {
        internal TraktApiMovieNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : base("Movie Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
