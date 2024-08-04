namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a person was not found.</summary>
    public sealed partial class TraktApiPersonNotFoundException : TraktApiObjectNotFoundException
    {
        public string PersonId => ObjectId;
    }
}
