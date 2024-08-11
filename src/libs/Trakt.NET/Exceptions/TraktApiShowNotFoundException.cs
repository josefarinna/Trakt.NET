namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a show was not found.</summary>
    public partial class TraktApiShowNotFoundException : TraktApiObjectNotFoundException
    {
        /// <summary>The not found show ID.</summary>
        public string ShowID => ObjectID;
    }
}
