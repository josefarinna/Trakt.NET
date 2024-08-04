namespace TraktNET
{
    /// <summary>
    /// Exception, that will be thrown, if there is a conflict on the server.
    /// For example, if a resource, e.g. a comment, already exists.
    /// </summary>
    public sealed partial class TraktApiConflictException : TraktApiException
    {
    }
}
