namespace TraktNET
{
    public partial class TraktApiObjectNotFoundException
    {
        internal TraktApiObjectNotFoundException(string message, ExceptionParameters parameters, Exception? innerException = null)
            : base(message, parameters, innerException)
            => ObjectID = parameters.ObjectId;

        internal TraktApiObjectNotFoundException(ExceptionParameters parameters, Exception? innerException = null)
            : this("Object Not Found - method exists, but no record found", parameters, innerException)
        {
        }
    }
}
