namespace TraktNET
{
    public partial class TraktApiSeasonNotFoundException
    {
        internal TraktApiSeasonNotFoundException(string message, ExceptionParameters parameters, Exception? innerException = null)
            : base(message, parameters, innerException)
            => SeasonNumber = parameters.SeasonNr;

        internal TraktApiSeasonNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : this("Season Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
