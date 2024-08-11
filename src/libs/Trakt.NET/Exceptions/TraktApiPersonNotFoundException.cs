namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a person was not found.</summary>
    public sealed partial class TraktApiPersonNotFoundException : TraktApiObjectNotFoundException
    {
        /// <summary>The not found person ID.</summary>
        public string PersonID => ObjectID;
    }
}
