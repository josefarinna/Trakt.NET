namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a show was not found.</summary>
    public partial class TraktApiShowNotFoundException : TraktApiObjectNotFoundException
    {
        public string ShowId => ObjectId;
    }
}
