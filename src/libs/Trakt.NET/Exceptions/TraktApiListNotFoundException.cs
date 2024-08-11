namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a list was not found.</summary>
    public sealed partial class TraktApiListNotFoundException : TraktApiObjectNotFoundException
    {
        /// <summary>The not found list ID.</summary>
        public string ListID => ObjectID;
    }
}
